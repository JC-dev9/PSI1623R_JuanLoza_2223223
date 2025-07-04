﻿// -------------------- IMPORTAÇÕES --------------------
using MaterialSkin.Controls;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeLightBible.Services;
using Newtonsoft.Json;
using System.Drawing.Drawing2D;
using BeLightBible.Controls;
using System.Linq;
using System.Speech.Synthesis;
using System.Data.SqlClient;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Cryptography.Xml;
using Newtonsoft.Json.Linq;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using NAudio.Wave;
using System.Diagnostics;

namespace BeLightBible
{

    public partial class MenuForm : MaterialForm
    {
        // -------------------- VARIÁVEIS --------------------

        private List<MenuForm> historiasKids;
        private int indiceAtualKids = 0;

        private static readonly HttpClient client = new HttpClient();
        private readonly Entities _context = new Entities();

        private PictureBox picLoading;
        private Label lblTituloCapitulo;
        private Label lblNumeroVersiculo;

        private Livro livros = new Livro();
        private Estilo estilo = new Estilo();
        private readonly ApiBibleService bibleService = new ApiBibleService();

        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private NotifyIcon notifyIcon1;

        private bool isPlaying = false;
        private bool isBusy = false;

        // API externa para bordas arredondadas
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeft, int nTop, int nRight, int nBottom, int nWidthEllipse, int nHeightEllipse);

        // -------------------- CONSTRUTOR --------------------
        public MenuForm()
        {
            InitializeComponent();
            CarregarLivros();

            // -------------------- COMPONENTES DINÂMICOS --------------------

            // PictureBox de loading
            picLoading = new PictureBox
            {
                Size = new Size(48, 48),
                ImageLocation = "loading.gif",
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(this.ClientSize.Width / 2 - 24, this.ClientSize.Height / 2 - 24),
                Visible = false,
                BackColor = Color.Transparent
            };
            this.Controls.Add(picLoading);
            picLoading.BringToFront();

            // Label do título do capítulo (não está sendo salvo na variável de classe)
            Label lblTituloCapitulo = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Margin = new Padding(5),
                Padding = new Padding(2),
                Location = new Point(flowLayoutPanelVersiculos.Left, flowLayoutPanelVersiculos.Top),
                Text = $"Versículo do dia"
            };

            // -------------------- CONFIGURAÇÕES DE LAYOUT --------------------

            // flowLayoutPanelVersiculos
            flowLayoutPanelVersiculos.Dock = DockStyle.Fill;
            flowLayoutPanelVersiculos.AutoScrollMargin = new Size(0, 3000);
            flowLayoutPanelVersiculos.AutoScroll = true;
            flowLayoutPanelVersiculos.WrapContents = false;
            flowLayoutPanelVersiculos.FlowDirection = FlowDirection.TopDown;

            // flowLayoutPanelConversa
            flowLayoutPanelConversa.Padding = new Padding(0, 0, 0, 70);
            flowLayoutPanelConversa.Dock = DockStyle.Fill;
            flowLayoutPanelConversa.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelConversa.WrapContents = false;
            flowLayoutPanelConversa.AutoScroll = true;

            // flowPanelPlanos
            flowPanelPlanos.Dock = DockStyle.Fill;
            flowPanelPlanos.FlowDirection = FlowDirection.TopDown;
            flowPanelPlanos.WrapContents = false;
            flowPanelPlanos.AutoScroll = true;
            flowPanelPlanos.AutoScrollMargin = new Size(0, 100);

            // ComboBoxes
            cmbLivro.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            cmbCapitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // -------------------- ESTILO: MaterialSkin --------------------
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey500,
                Primary.BlueGrey700,
                Primary.BlueGrey100,
                Accent.DeepOrange200,
                TextShade.WHITE
            );

            // -------------------- EVENTOS --------------------
            this.Load += MenuForm_Load;
            this.Load += FormPrincipal_Load;

            this.Resize += MenuForm_Resize;
            this.Resize += (s, e) =>
            {
                AtualizarLarguraDosCards(flowLayoutPanelAnotacoes);
                AtualizarLarguraDosCards(flowPanelPlanos);
                AjustarFonteCards();
            };

            TabControlPrincipal.SelectedIndexChanged += (s, e) =>
            {
                AtualizarLarguraDosCards(flowLayoutPanelAnotacoes);
                AtualizarLarguraDosCards(flowPanelPlanos);
                AjustarFonteCards();
                CarregarUltimoPonto();
                AplicarLayoutResponsivoBible();
                AtualizarLarguraDasMensagens();
            };

            flowLayoutPanelConversa.Resize += flowLayoutPanelConversa_Resize;

            cmbLivro.SelectedIndexChanged += cmbLivro_SelectedIndexChanged;

            this.picAudio.Click += new System.EventHandler(this.picAudio_Click);

            // -------------------- ESTILIZAÇÃO --------------------

            // Bible
            estilo.EstilizarPictureBoxComoBotao(picBtnProximoCapitulo, true, cmbLivro, cmbCapitulo, BibleTab);
            estilo.EstilizarPictureBoxComoBotao(picBtnAnteriorCapitulo, false, cmbLivro, cmbCapitulo, BibleTab);
            estilo.EstilizarPictureBoxAudio(picAudio);

            estilo.ArredondarControle(picBtnProximoCapitulo, 10);
            estilo.ArredondarControle(picBtnAnteriorCapitulo, 10);
            estilo.ArredondarControle(picAudio, 10);

            // Bible Kids
            estilo.EstilizarPictureBoxComoBotao(picBtnProximaHistoria);
            estilo.EstilizarPictureBoxComoBotao(picBtnVoltarHistoria);
            estilo.ArredondarControle(picBtnProximaHistoria, 10);
            estilo.ArredondarControle(picBtnVoltarHistoria, 10);

            // Ajustes visuais finais
            AplicarLayoutResponsivoBible();
            AtualizarLarguraDasMensagens();
            AtualizarLarguraDosCards(flowLayoutPanelAnotacoes);
            AtualizarLarguraDosCards(flowPanelPlanos);
            AjustarFonteCards();
        }


        // -------------------- LAYOUT --------------------
        private void MenuForm_Resize(object sender, EventArgs e)
        {
            AplicarLayoutResponsivoBible();
            AtualizarLarguraDasMensagens();
        }

        private HistoriasKidsTab historiasTab;
        private PlanoLeitura planoLeituraTab;

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
        }
        private async void MenuForm_Load(object sender, EventArgs e)
        {
            historiasTab = new HistoriasKidsTab(tabBibleKids, pnlBibleKidPrincipal, picBtnProximaHistoria, picBtnVoltarHistoria, cardTextoHistoria, pictureBoxImagemHistoria, pnlBibleKids);

            CriarCardUltimoPonto();
            CarregarUltimoPonto();
            CriarLabelsVersiculoDia();
            await CarregarVersiculoDiaAsync(); // Carrega o versículo do dia na tela inicial

            CarregarAnotacoes();
            CarregarPlanoLeituraTodos();

            //Definições
            CriarPainelDeConfiguracoes(panelSettings); // 'meuPanel' é o nome do painel do Designer


            await AtualizarInterfaceCompletaAsync();

            SwitchManterSessao.Checked = Properties.Settings.Default.ManterSessao;

        }
        public async Task AtualizarInterfaceCompletaAsync()
        {
            // Recarregar anotações
            CarregarAnotacoes();
            AtualizarLarguraDosCards(flowLayoutPanelAnotacoes);
            AtualizarLarguraDosCards(flowPanelPlanos);
            AjustarFonteCards();

            // Tela inicial
            CriarCardUltimoPonto();
            CarregarUltimoPonto();
            CriarLabelsVersiculoDia();
            await CarregarVersiculoDiaAsync();

            // Tela Bíblia Kids
 
            historiasTab.CriarComponentes();
            historiasTab.MostrarHistoriaAtual();
            historiasTab.InicializarHistorias();
            historiasTab.CriarTituloPrincipal();

            // Estilo Bíblia
            estilo.EstilizarPictureBoxComoBotao(picBtnProximoCapitulo, true, cmbLivro, cmbCapitulo, BibleTab);
            estilo.EstilizarPictureBoxComoBotao(picBtnAnteriorCapitulo, false, cmbLivro, cmbCapitulo, BibleTab);
            estilo.EstilizarPictureBoxAudio(picAudio);

            estilo.ArredondarControle(picBtnProximoCapitulo, 10);
            estilo.ArredondarControle(picBtnAnteriorCapitulo, 10);
            estilo.ArredondarControle(picAudio, 10);

            // Estilo Bíblia Kids
            estilo.EstilizarPictureBoxComoBotao(picBtnProximaHistoria);
            estilo.EstilizarPictureBoxComoBotao(picBtnVoltarHistoria);
            estilo.ArredondarControle(picBtnProximaHistoria, 10);
            estilo.ArredondarControle(picBtnVoltarHistoria, 10);
        }



        private void AtualizarLarguraDosCards(FlowLayoutPanel flowLayoutPanel)
        {
            foreach (Control control in flowLayoutPanel.Controls)
            {
                if (control is MaterialCard card)
                {
                    card.Width = flowLayoutPanel.ClientSize.Width - 30;
                }
            }
        }

        private void AjustarFonteCards()
        {
            float baseWidth = 800f; // largura base para o design original
            float scaleFactor = this.ClientSize.Width / baseWidth;

            float baseFontSizeReferencia = 10f;
            float baseFontSizeTexto = 11f;
            float baseFontSizeBtn = 9f;

            // limita o tamanho para não ficar muito pequeno nem muito grande
            float fontSizeReferencia = Math.Min(Math.Max(11f, baseFontSizeReferencia * scaleFactor), 14f);
            float fontSizeTexto = Math.Min(Math.Max(11f, baseFontSizeTexto * scaleFactor), 16f);

            foreach (Control ctrl in flowLayoutPanelAnotacoes.Controls)
            {
                if (ctrl is MaterialCard card)
                {
                    foreach (Control child in card.Controls)
                    {
                        if (child is Label lbl)
                        {
                            if (lbl.Font.Style == FontStyle.Bold)
                                lbl.Font = new Font("Segoe UI", fontSizeReferencia, FontStyle.Bold);
                            else
                                lbl.Font = new Font("Segoe UI", fontSizeTexto, FontStyle.Regular);
                        }

                    }
                }
            }
        }
        private void AdicionarEspacadorFinal()
        {
            // Remove espaçadores antigos
            foreach (Control ctrl in flowLayoutPanelConversa.Controls.OfType<Panel>().Where(p => p.Tag?.ToString() == "espacador").ToList())
            {
                flowLayoutPanelConversa.Controls.Remove(ctrl);
            }

            var espacador = new Panel
            {
                Height = 50,
                Width = 0,
                BackColor = Color.Transparent,
                Margin = new Padding(0),
                Tag = "espacador"
            };

            flowLayoutPanelConversa.Controls.Add(espacador);
        }
        private void SetRoundedRegion(Control control, int radius)
        {
            var region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, radius, radius));
            control.Region = region;
        }

        private void AtualizarLarguraDasMensagens()
        {
            int maxWidth = flowLayoutPanelConversa.ClientSize.Width - 30;

            foreach (Panel panel in flowLayoutPanelConversa.Controls.OfType<Panel>())
            {
                panel.MaximumSize = new Size(maxWidth, 0);
                if (panel.Controls.Count > 0 && panel.Controls[0] is Label label)
                {
                    label.MaximumSize = new Size(maxWidth - 20, 0);
                    label.Refresh();
                }
                panel.Refresh();
            }
        }

        private void flowLayoutPanelConversa_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in flowLayoutPanelConversa.Controls)
            {
                if (ctrl is Panel bubble)
                {
                    bubble.MaximumSize = new Size(flowLayoutPanelConversa.Width - 100, 0);

                    if (bubble.Controls.Count > 0 && bubble.Controls[0] is Label label)
                    {
                        label.MaximumSize = new Size(bubble.MaximumSize.Width - 20, 0);
                    }
                }
            }
        }

        private void AplicarLayoutResponsivoBible()
        {
            // Centraliza o loading
            picLoading.Location = new Point(
                (this.ClientSize.Width - picLoading.Width) / 2,
                (this.ClientSize.Height - picLoading.Height) / 2);

            // Ajusta largura das labels
            foreach (Control ctrl in flowLayoutPanelVersiculos.Controls)
            {
                if (ctrl is Panel card && card.Controls.Count > 0 && card.Controls[0] is Label lbl)
                {
                    lbl.MaximumSize = new Size(flowLayoutPanelVersiculos.ClientSize.Width - 20, 0);
                }
                else if (ctrl is Label lblDireto)
                {
                    lblDireto.MaximumSize = new Size(flowLayoutPanelVersiculos.ClientSize.Width - 20, 0);
                }
            }

            AjustarFonteControles();
        }

        private void AjustarFonteControles()
        {
            float baseWidth = 800f;
            float scaleFactor = this.ClientSize.Width / baseWidth;
            float baseFontSize = 14f;
            float newFontSize = baseFontSize * scaleFactor;
            float fontSizeLimitada = Math.Min(Math.Max(10f, newFontSize), 20f);

            foreach (Control ctrl in flowLayoutPanelVersiculos.Controls)
            {
                if (ctrl is Panel card && card.Controls.Count > 0 && card.Controls[0] is Label lbl)
                {
                    lbl.Font = new Font("Segoe UI", fontSizeLimitada, FontStyle.Italic);
                }
                else if (ctrl is Label lblDireto)
                {
                    lblDireto.Font = new Font("Segoe UI", fontSizeLimitada, FontStyle.Bold);
                }
            }
        }

        // ----------------------------------------------------------------
        // -------------------- CHATBOT LLM ------------------------------
        // ----------------------------------------------------------------
        private Panel CreateMessageBubble(string message, bool isUser)
        {
            var panel = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(10),
                Margin = new Padding(5, 5, 5, 50),
                BackColor = isUser ? Color.FromArgb(33, 150, 243) : Color.FromArgb(97, 97, 97),
            };

            var label = new Label
            {
                Text = message,
                AutoSize = true,
                Cursor = Cursors.Hand,
                MaximumSize = new Size(flowLayoutPanelConversa.ClientSize.Width - 50, 0),
                Font = new Font("Segoe UI", 13),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };


            label.MouseClick += MensagemClicada;
            panel.Controls.Add(label);

            // Arredondar balão
            panel.SizeChanged += (s, e) =>
            {
                panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 20, 20));
            };

            return panel;
        }

        private void AddUserMessage(string text)
        {
            var userMsg = CreateMessageBubble(text, true);
            flowLayoutPanelConversa.Controls.Add(userMsg);
            flowLayoutPanelConversa.ScrollControlIntoView(userMsg);
        }

        private void AddBotMessage(string text)
        {
            var botMsg = CreateMessageBubble(text, false);
            flowLayoutPanelConversa.Controls.Add(botMsg);
            flowLayoutPanelConversa.ScrollControlIntoView(botMsg);
            AdicionarEspacadorFinal();
        }

        public async Task<float[]> ObterEmbeddingOllamaAsync(string texto)
        {
            var url = "http://localhost:11434/api/embeddings";
            var requestData = new
            {
                model = "nomic-embed-text",
                prompt = texto
            };

            var json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(jsonResponse);

            JArray embeddingArray = result.embedding;
            return embeddingArray.ToObject<float[]>();
        }

        public async Task<RespostasCache> BuscarRespostaCacheAsync(string pergunta)
        {
            var embeddingAtual = await ObterEmbeddingOllamaAsync(pergunta); // Irá retornar algo como: [0.1234, -0.5678, 0.9012, ...]

            var todosCaches = await _context.RespostasCache.ToListAsync();

            double threshold = 0.92;
            RespostasCache melhorCache = null;
            double melhorSimilaridade = 0;

            foreach (var cache in todosCaches)
            {
                var embeddingCache = cache.EmbeddingArray;
                var similaridade = CosineSimilarity(embeddingAtual, embeddingCache);

                if (similaridade > melhorSimilaridade)
                {
                    melhorSimilaridade = similaridade;
                    melhorCache = cache;
                }
            }

            if (melhorSimilaridade >= threshold)
                return melhorCache;

            return null;
        }

        public static double CosineSimilarity(float[] vectorA, float[] vectorB)
        {
            if (vectorA.Length != vectorB.Length)
                throw new ArgumentException("Vetores com tamanhos diferentes");

            double dot = 0;
            double magA = 0;
            double magB = 0;

            for (int i = 0; i < vectorA.Length; i++)
            {
                dot += vectorA[i] * vectorB[i];
                magA += vectorA[i] * vectorA[i];
                magB += vectorB[i] * vectorB[i];
            }

            magA = Math.Sqrt(magA);
            magB = Math.Sqrt(magB);

            if (magA == 0 || magB == 0) return 0;

            return dot / (magA * magB);
        }

        private async Task EnviarParaOllama(string pergunta)
        {
            try
            {
                // Busca no cache
                var respostaCache = await BuscarRespostaCacheAsync(pergunta);
                if (respostaCache != null)
                {
                    AddBotMessage(respostaCache.Resposta);
                    return; // Se encontrou no cache, não precisa enviar para o LLM
                }

                string promptBase = @"Você é um especialista em Bíblia, teologia cristã e princípios do cristianismo.
Todas as suas respostas devem ser baseadas nas Escrituras Sagradas, na fé cristã e em valores bíblicos.
Mesmo que a pergunta não pareça religiosa, responda de forma que conecte com a Bíblia, princípios cristãos ou histórias bíblicas.

Agora responda a seguinte pergunta em Portugues de Portugal de forma clara, com base nesses princípios:
";

                string promptFinal = promptBase + pergunta;


                var url = "https://api.groq.com/openai/v1/chat/completions";

                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "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");

                var requestData = new
                {
                    model = "llama-3.3-70b-versatile",
                    messages = new[]
                    {
                        new { role = "user", content = promptFinal }
                    },
                    stream = true,
                };

                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };

                var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                var stream = await response.Content.ReadAsStreamAsync();
                var reader = new StreamReader(stream);

                var botBubble = CreateMessageBubble("", false);
                var botLabel = (Label)botBubble.Controls[0];
                flowLayoutPanelConversa.Controls.Add(botBubble);
                flowLayoutPanelConversa.ScrollControlIntoView(botBubble);

                string respostaCompleta = "";

                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    if (line.StartsWith("data: ")) line = line.Substring(6);
                    if (line == "[DONE]") break;

                    dynamic obj = JsonConvert.DeserializeObject(line);
                    string contentPart = obj?.choices[0]?.delta?.content;

                    if (contentPart != null)
                    {
                        respostaCompleta += contentPart;
                        botLabel.Text += contentPart;
                        botBubble.Width = botLabel.PreferredWidth + 20;
                        Application.DoEvents();
                    }
                }


                var embeddingPergunta = await ObterEmbeddingOllamaAsync(pergunta);
                var novaRespostaCache = new RespostasCache
                {
                    Pergunta = pergunta,
                    Resposta = respostaCompleta,
                    EmbeddingArray = embeddingPergunta
                };

                _context.RespostasCache.Add(novaRespostaCache);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                AddBotMessage("Erro: " + ex.Message);
            }
        }


        private async void btnEnviarChatbot_Click(object sender, EventArgs e)
        {
            string pergunta = txtPergunta.Text.Trim();
            txtPergunta.Clear();

            if (string.IsNullOrWhiteSpace(pergunta))
            {
                MessageBox.Show("Digite uma pergunta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            AddUserMessage(pergunta); // mostra mensagem do usuário

            txtPergunta.Clear();
            await EnviarParaOllama(pergunta);
        }


        private void MensagemClicada(object sender, MouseEventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.Font = new Font(lbl.Font, lbl.Font.Style | FontStyle.Underline);
                Versiculo versiculo = new Versiculo(lbl);

                ContextMenuStrip menu = new ContextMenuStrip();

                menu.Items.Add(new ToolStripMenuItem("Copiar", Image.FromFile("icons/copy.png"), (s, ev) => versiculo.Copiar()));


                menu.Closed += (s, ev) =>
                {
                    lbl.Font = new Font(lbl.Font, lbl.Font.Style & ~FontStyle.Underline);
                };

                menu.Show(lbl, new Point(e.X, e.Y));
            }
        }

        // -------------------- CARREGAMENTO BIBLIA --------------------
        private void CarregarLivros()
        {
            var livrosDictionary = livros.ObterLivros();

            foreach (var livro in livrosDictionary)
            {
                cmbLivro.Items.Add(livro.Key);
            }
        }
        private void txtPergunta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita o som "beep"
                btnEnviarChatbot.PerformClick(); // Simula clique no botão
            }
        }

        private async Task BibleTab(string livro, int capitulo)
        {
            picLoading.Visible = true;

            var data = await bibleService.BuscarVersiculo(livro, capitulo);

            if (data == null || data.verses == null)
            {
                MessageBox.Show("Erro ao buscar versículos da API.");
                return;
            }

            flowLayoutPanelVersiculos.Controls.Clear();

            string fonte = "Segoe UI";

            lblTituloCapitulo = new Label
            {
                AutoSize = true,
                Font = new Font(fonte, 14, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Margin = new Padding(1),
                Padding = new Padding(1),
                Location = new Point(flowLayoutPanelVersiculos.Left, flowLayoutPanelVersiculos.Top),
                Text = $"{livro.ToUpper()} {capitulo}"
            };


            flowLayoutPanelVersiculos.Controls.Add(lblTituloCapitulo);
            var grifos = Versiculo.ObterGrifosUtilizador(Sessao.UserId, livro, capitulo);

            foreach (var versiculo in data.verses)
            {
                Label lbl = new Label
                {
                    Text = $"{versiculo.verse}: {versiculo.text}",
                    Tag = versiculo.verse,
                    Cursor = Cursors.Hand,
                    AutoSize = true,
                    MaximumSize = new Size(flowLayoutPanelVersiculos.ClientSize.Width - 20, 0),
                    Font = new Font(fonte, 12, FontStyle.Italic),
                    Margin = new Padding(1),
                    Padding = new Padding(1),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent
                };


                foreach (var item in grifos)
                {
                    if (item.Versiculo == Convert.ToInt32(lbl.Tag))
                    {
                        lbl.BackColor = ColorTranslator.FromHtml(item.Cor);
                    }
                }

                lbl.MouseClick += VersiculoClicado;

                var card = new Panel
                {
                    Padding = new Padding(1),
                    Margin = new Padding(1),
                    AutoSize = true
                };

                card.Controls.Add(lbl);
                flowLayoutPanelVersiculos.Controls.Add(card);
            }

            var espacoAbaixo = new Panel
            {
                Height = 50,
                Width = 0,
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            };

            flowLayoutPanelVersiculos.Controls.Add(espacoAbaixo);

            AplicarLayoutResponsivoBible();
            picLoading.Visible = false;
            Versiculo.SalvarUltimoPonto(Sessao.UserId, livro, capitulo);
        }

        // -------------------- EVENTOS --------------------
        private void cmbLivro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomeLivro = cmbLivro.SelectedItem as string;

            if (string.IsNullOrEmpty(nomeLivro)) return;

            cmbCapitulo.Items.Clear();

            int totalCapitulos = livros.ObterNumeroDeCapitulos(nomeLivro);

            for (int i = 1; i <= totalCapitulos; i++)
            {
                cmbCapitulo.Items.Add(i.ToString());
            }

            if (cmbCapitulo.Items.Count > 0)
            {
                cmbCapitulo.SelectedIndex = 0;
            }
        }

        private async void VersiculoClicado(object sender, MouseEventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.Font = new Font(lbl.Font, lbl.Font.Style | FontStyle.Underline);
                Versiculo versiculo = new Versiculo(lbl);

                string livro = cmbLivro.SelectedItem.ToString();
                int capitulo = int.Parse(cmbCapitulo.SelectedItem.ToString());
                int versNumero = Convert.ToInt32(lbl.Tag);
                string mensagem = $"{lbl.Text.TrimEnd()} - {livro} {capitulo}:{versNumero}";

                ContextMenuStrip menu = new ContextMenuStrip();

                // Sublinhar
                menu.Items.Add(new ToolStripMenuItem("Sublinhar", Image.FromFile("icons/palette.png"), (s, ev) =>
                {
                    versiculo.Grifar(Sessao.UserId, livro, capitulo, versNumero, lbl.Text);
                }));

                // Copiar
                menu.Items.Add(new ToolStripMenuItem("Copiar", Image.FromFile("icons/copy.png"), (s, ev) => versiculo.Copiar()));

                // Anotar
                menu.Items.Add(new ToolStripMenuItem("Anotar", Image.FromFile("icons/notepad.png"), async (s, ev) =>
                {
                    await versiculo.Anotar(Sessao.UserId, livro, capitulo, versNumero,
                        async () => await BibleTab(livro, capitulo));

                    estilo.EstilizarPictureBoxComoBotao(picBtnProximoCapitulo, true, cmbLivro, cmbCapitulo, BibleTab);
                    estilo.EstilizarPictureBoxComoBotao(picBtnAnteriorCapitulo, false, cmbLivro, cmbCapitulo, BibleTab);
                    estilo.EstilizarPictureBoxAudio(picAudio);

                    estilo.ArredondarControle(picBtnProximoCapitulo, 10);
                    estilo.ArredondarControle(picBtnAnteriorCapitulo, 10);
                    estilo.ArredondarControle(picAudio, 10);

                    CarregarAnotacoes();
                    CriarCardUltimoPonto();
                    CarregarUltimoPonto();
                    CriarLabelsVersiculoDia();
                    await CarregarVersiculoDiaAsync();
                }));

                // Explicar
                ToolStripMenuItem explicarMenu = new ToolStripMenuItem("Explicar", Image.FromFile("icons/ai.png"));

                // Opção 1: Contexto histórico e teológico (como antes)
                explicarMenu.DropDownItems.Add("Contexto histórico e teológico", Image.FromFile("icons/scroll-text.png"), async (s, ev) =>
                {
                    string prompt = $"Você é um especialista bíblico. Explique com clareza e profundidade o contexto histórico, cultural e teológico do versículo {livro} {capitulo}:{versNumero}, que diz: \"{lbl.Text}\".";
                    TabControlPrincipal.SelectedTab = tabChatbot;
                    AddUserMessage(prompt);
                    await EnviarParaOllama(prompt);
                });

                // Opção 2: Curiosidades sobre o versículo
                explicarMenu.DropDownItems.Add("Curiosidades", Image.FromFile("icons/lightbulb.png"), async (s, ev) =>
                {
                    string prompt = $"Conte curiosidades interessantes sobre o versículo {livro} {capitulo}:{versNumero}, \"{lbl.Text}\".";
                    TabControlPrincipal.SelectedTab = tabChatbot;
                    AddUserMessage(prompt);
                    await EnviarParaOllama(prompt);
                });

                // Opção 3: Aplicação prática para a vida
                explicarMenu.DropDownItems.Add("Aplicação prática", Image.FromFile("icons/handshake.png"), async (s, ev) =>
                {
                    string prompt = $"Explique como aplicar o versículo {livro} {capitulo}:{versNumero} na vida cristã diária.";
                    TabControlPrincipal.SelectedTab = tabChatbot;
                    AddUserMessage(prompt);
                    await EnviarParaOllama(prompt);
                });

                // Opção 4: Perguntas frequentes (FAQ) sobre o versículo
                explicarMenu.DropDownItems.Add("Perguntas frequentes", Image.FromFile("icons/message-circle-question-mark.png"), async (s, ev) =>
                {
                    string prompt = $"Liste e responda perguntas frequentes relacionadas ao versículo {livro} {capitulo}:{versNumero}.";
                    TabControlPrincipal.SelectedTab = tabChatbot;
                    AddUserMessage(prompt);
                    await EnviarParaOllama(prompt);
                });

                // Adiciona o submenu ao menu principal
                menu.Items.Add(explicarMenu);


                // Compartilhar (submenu)
                ToolStripMenuItem compartilharMenu = new ToolStripMenuItem("Compartilhar", Image.FromFile("icons/share-2.png"));

                // Copiar
                compartilharMenu.DropDownItems.Add("Copiar", Image.FromFile("icons/copy.png"), (s, ev) =>
                {
                    Clipboard.SetText(mensagem);
                    MessageBox.Show("Versículo copiado para a área de transferência!");
                });

                // WhatsApp
                compartilharMenu.DropDownItems.Add("Compartilhar via WhatsApp", Image.FromFile("icons/whatsapp.png"), (s, ev) =>
                {
                    string url = $"https://wa.me/?text={Uri.EscapeDataString(mensagem)}";
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                });

                // Email
                compartilharMenu.DropDownItems.Add("Compartilhar por Email", Image.FromFile("icons/email.png"), (s, ev) =>
                {
                    string assunto = Uri.EscapeDataString("Versículo do Dia");
                    string corpo = Uri.EscapeDataString(mensagem);
                    string url = $"mailto:?subject={assunto}&body={corpo}";
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                });

                compartilharMenu.DropDownItems.Add("Salvar como Imagem", Image.FromFile("icons/image.png"), (s, ev) =>
                {
                    // Configura fonte e cores
                    Font fonte = new Font("Segoe UI", 18, FontStyle.Bold);
                    Color corFundo = Color.FromArgb(245, 245, 245);
                    Color corTexto = Color.FromArgb(40, 40, 40);
                    Color corSombra = Color.FromArgb(0, 0, 0, 0);

                    // Calcula tamanho da imagem baseado no texto (com margem)
                    int largura = 800;
                    int margem = 30;
                    SizeF tamanhoTexto;

                    using (var bmpTmp = new Bitmap(1, 1))
                    using (var gTmp = Graphics.FromImage(bmpTmp))
                    {
                        var areaTexto = new RectangleF(0, 0, largura - 2 * margem, 1000);
                        var sf = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near };
                        tamanhoTexto = gTmp.MeasureString(mensagem, fonte, areaTexto.Size, sf);
                    }

                    int altura = (int)tamanhoTexto.Height + margem * 2;

                    Bitmap bmp = new Bitmap(largura, altura);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.Clear(corFundo);

                        var areaTexto = new RectangleF(margem, margem, largura - 2 * margem, altura - 2 * margem);
                        var sf = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near };

                        // Desenha sombra do texto
                        using (Brush sombra = new SolidBrush(corSombra))
                        {
                            g.DrawString(mensagem, fonte, sombra, new RectangleF(areaTexto.X + 2, areaTexto.Y + 2, areaTexto.Width, areaTexto.Height), sf);
                        }

                        // Desenha texto principal
                        using (Brush bTexto = new SolidBrush(corTexto))
                        {
                            g.DrawString(mensagem, fonte, bTexto, areaTexto, sf);
                        }

                        // Opcional: desenhar uma linha fina na base para decorar
                        using (Pen pen = new Pen(Color.Orange, 3))
                        {
                            g.DrawLine(pen, margem, altura - margem / 2, largura - margem, altura - margem / 2);
                        }
                    }

                    SaveFileDialog saveDialog = new SaveFileDialog
                    {
                        Filter = "Imagem PNG|*.png",
                        FileName = "versiculo.png"
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        bmp.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        MessageBox.Show("Imagem salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                });

                menu.Items.Add(compartilharMenu);

                // Restaurar estilo ao fechar menu
                menu.Closed += (s, ev) =>
                {
                    lbl.Font = new Font(lbl.Font, lbl.Font.Style & ~FontStyle.Underline);
                };

                menu.Show(lbl, new Point(e.X, e.Y));
            }
        }


        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string livro = cmbLivro.SelectedItem as string;

            if (string.IsNullOrEmpty(livro))
            {
                MessageBox.Show("Selecione um livro.");
                return;
            }

            if (!int.TryParse(cmbCapitulo.SelectedItem?.ToString(), out int capitulo))
            {
                MessageBox.Show("Selecione um capítulo válido.");
                return;
            }

            await BibleTab(livro, capitulo);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ManterSessao = false;
            Properties.Settings.Default.UsernameSalvo = "";
            Properties.Settings.Default.UserIdSalvo = 0;
            Properties.Settings.Default.Save();

            this.Close(); // fecha o form atual
            Application.Restart();
        }



        private void tabPage4_Click(object sender, EventArgs e) { }

        // -------------------- ÁUDIO --------------------

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        private async void picAudio_Click(object sender, EventArgs e)
        {
            if (isBusy) return; // já está executando alguma coisa
            isBusy = true;

            try
            {
                if (isPlaying)
                {
                    PararAudio();
                    return;
                }

                string texto = ObterTextoDosVersiculos();

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    bool sucesso = false;

                    await Task.Run(() =>
                    {
                        sucesso = GerarAudioPython(texto);
                    });

                    if (sucesso)
                    {
                        picAudio.Image = Image.FromFile("pause.png");
                        TocarAudio();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gerar áudio.");
                        picAudio.Image = Image.FromFile("volume-2-white.png");
                    }
                }
            }
            finally
            {
                isBusy = false;
            }
        }

        private void Synthesizer_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    picAudio.Image = Image.FromFile("volume-2-white.png");
                    isPlaying = false;
                }));
            }
            else
            {
                picAudio.Image = Image.FromFile("volume-2-white.png");
                isPlaying = false;
            }
        }

        private void TocarAudio()
        {
            try
            {
                if (outputDevice != null || isPlaying) return;

                string mp3File = Path.Combine(Path.GetDirectoryName(@"C:\Users\juanl\bibleVoice\tts.py"), "temp_ptpt.mp3");

                if (!File.Exists(mp3File))
                {
                    MessageBox.Show("Arquivo de áudio não encontrado: " + mp3File);
                    picAudio.Image = Image.FromFile("volume-2-white.png");
                    isPlaying = false;
                    return;
                }

                outputDevice = new WaveOutEvent();
                audioFile = new AudioFileReader(mp3File);
                outputDevice.Init(audioFile);
                outputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;

                isPlaying = true;
                picAudio.Image = Image.FromFile("pause.png");
                outputDevice.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tocar áudio: " + ex.Message);
                isPlaying = false;
                picAudio.Image = Image.FromFile("volume-2-white.png");
            }
        }


        private bool GerarAudioPython(string texto)
        {
            try
            {
                string pythonExe = @"C:\Users\juanl\bibleVoice\myenv\Scripts\python.exe";
                string scriptPath = @"C:\Users\juanl\bibleVoice\tts.py";


                // Passa texto como argumento, escapando aspas e caracteres especiais
                string argumento = $"\"{texto.Replace("\"", "\\\"")}\"";

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = pythonExe;
                psi.Arguments = $"\"{scriptPath}\" {argumento}";
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;

                using (Process p = Process.Start(psi))
                {
                    p.WaitForExit();
                    string stderr = p.StandardError.ReadToEnd();
                    if (p.ExitCode != 0)
                    {
                        // Debug - erro do python
                        Console.WriteLine("Python error: " + stderr);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao executar Python: " + ex.Message);
                return false;
            }
        }

        private void PararAudio()
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                // LiberarAudio() será chamado no evento PlaybackStopped.
            }
        }

        private void OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                LiberarAudio();
            }));
        }

        private void LiberarAudio()
        {
            if (outputDevice != null)
            {
                outputDevice.PlaybackStopped -= OutputDevice_PlaybackStopped; // desvincula evento
                outputDevice.Dispose();
                outputDevice = null;
            }

            if (audioFile != null)
            {
                audioFile.Dispose();
                audioFile = null;
            }

            try
            {
                string mp3File = Path.Combine(Path.GetDirectoryName(@"C:\Users\juanl\bibleVoice\tts.py"), "temp_ptpt.mp3");
                if (File.Exists(mp3File))
                    File.Delete(mp3File);
            }
            catch { }

            picAudio.Image = Image.FromFile("volume-2-white.png");
            isPlaying = false;
        }


        private string ObterTextoDosVersiculos()
        {
            string texto = "";

            foreach (Control ctrl in flowLayoutPanelVersiculos.Controls)
            {
                if (ctrl is Panel card && card.Controls.Count > 0 && card.Controls[0] is Label lbl)
                {
                    texto += lbl.Text + " ";
                }
                else if (ctrl is Label lblDireto)
                {
                    texto += lblDireto.Text + " ";
                }
            }

            return texto.Trim();
        }

        // ----------------------------------------------------------------
        // -------------------- TELA INICIAL ------------------------------
        // ----------------------------------------------------------------

        private void CriarLabelsVersiculoDia()
        {
            cardVersiculoDia.Controls.Clear();

            lblTituloCapitulo = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Margin = new Padding(5),
                Padding = new Padding(2),
                Text = "Versículo do Dia",
                Location = new Point(20, 20)
            };

            lblTextoVersiculo = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(300, 0),
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Padding = new Padding(2),
                Location = new Point(20, 60)
            };

            lblNumeroVersiculo = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.LightGray,
                BackColor = Color.Transparent,
                Location = new Point(20, 130)
            };

            cardVersiculoDia.Controls.Add(lblTituloCapitulo);
            cardVersiculoDia.Controls.SetChildIndex(lblTituloCapitulo, 0); // Move para o topo

            cardVersiculoDia.Controls.Add(lblTextoVersiculo);
            cardVersiculoDia.Controls.Add(lblNumeroVersiculo);
            cardVersiculoDia.Controls.Add(btnCompartilharVersiculo);
            cardVersiculoDia.Controls.Add(btnSalvarVersiculo);
        }

        private void AtualizarVersiculo(string texto, string referencia)
        {
            lblTextoVersiculo.AutoSize = false;
            lblTextoVersiculo.Width = 300;
            lblTextoVersiculo.TextAlign = ContentAlignment.TopLeft;

            lblTextoVersiculo.Text = $"\"{texto}\"";

            // Ajusta altura para que o texto quebre linhas corretamente
            Size textSize = TextRenderer.MeasureText(texto, lblTextoVersiculo.Font, new Size(lblTextoVersiculo.Width, 0), TextFormatFlags.WordBreak);
            lblTextoVersiculo.Height = textSize.Height + 10;

            // Reposiciona o lblNumeroVersiculo logo abaixo do lblTextoVersiculo
            lblNumeroVersiculo.Location = new Point(lblTextoVersiculo.Left, lblTextoVersiculo.Top + lblTextoVersiculo.Height + 2);
            lblNumeroVersiculo.Text = referencia;
        }

        // -------------------- GERAR VERSÍCULO --------------------

        private async Task CarregarVersiculoDiaAsync()
        {
            string hoje = DateTime.Now.ToString("yyyy-MM-dd");

            // Verifica se já foi carregado hoje
            if (Properties.Settings.Default.DataUltimoVersiculo == hoje)
            {
                string textoSalvo = Properties.Settings.Default.UltimoVersiculo;
                string referenciaSalva = Properties.Settings.Default.UltimaReferencia;
                AtualizarVersiculo(textoSalvo, referenciaSalva);
                lblNumeroVersiculo.Text = $"{referenciaSalva}";
                return;
            }

            // Se não, busca novo versículo
            var api = new ApiBibleService();
            dynamic versiculo = await api.BuscarVersiculoAleatorio();

            if (versiculo != null)
            {
                string texto = versiculo.text.ToString().Trim();
                string referencia = $"{versiculo.book_name} {versiculo.chapter}:{versiculo.verse}";

                AtualizarVersiculo(texto, referencia);
                lblNumeroVersiculo.Text = $"{referencia}";

                // Salva nas configurações
                Properties.Settings.Default.UltimoVersiculo = texto;
                Properties.Settings.Default.UltimaReferencia = referencia;
                Properties.Settings.Default.DataUltimoVersiculo = hoje;
                Properties.Settings.Default.Save();

                MostrarNotificacaoVersiculoDoDia();
            }
            else
            {
                lblTextoVersiculo.Text = "Não foi possível carregar o versículo do dia.";
            }
        }

        private void MostrarNotificacaoVersiculoDoDia()
        {
            notifyIcon1 = new NotifyIcon();
            notifyIcon1.Icon = SystemIcons.Information; // ícone padrão do sistema
            notifyIcon1.Visible = true;

            if (notifyIcon1 == null)
                return;

            string mensagem = ObterMensagemVersiculo();

            if (string.IsNullOrEmpty(mensagem))
                return;

            notifyIcon1.BalloonTipTitle = "Versículo do Dia";
            notifyIcon1.BalloonTipText = mensagem;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(5000); // mostra por 5 segundos
        }


        // -------------------- SALVAR VERSICULO --------------------
        private void btnSalvarVersiculo_Click(object sender, EventArgs e)
        {
            int userId = Sessao.UserId;
            string texto = Properties.Settings.Default.UltimoVersiculo;
            string referencia = Properties.Settings.Default.UltimaReferencia;

            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(referencia))
            {
                MessageBox.Show("Nenhum versículo disponível para salvar.");
                return;
            }

            Versiculo v = new Versiculo(lblTextoVersiculo); // você pode usar qualquer Label aqui, ou refatorar se não precisar mais dela
            v.SalvarVersiculoEF(userId, referencia, texto);
        }

        // -------------------- COMPARTILHAR VERSÍCULO --------------------

        private void btnCompartilharVersiculo_Click(object sender, EventArgs e)
        {
            string mensagem = ObterMensagemVersiculo();

            if (mensagem == null)
            {
                MessageBox.Show("Nenhum versículo para compartilhar.");
                return;
            }

            ContextMenuStrip menu = new ContextMenuStrip();

            // Item: Copiar para área de transferência
            ToolStripMenuItem copiarItem = new ToolStripMenuItem("Copiar");
            copiarItem.Image = Image.FromFile("icons/copy.png");
            copiarItem.Click += (s, ev) =>
            {
                Clipboard.SetText(mensagem);
                MessageBox.Show("Versículo copiado para a área de transferência!");
            };

            // Item: Compartilhar via WhatsApp
            ToolStripMenuItem whatsappItem = new ToolStripMenuItem("Compartilhar via WhatsApp");
            whatsappItem.Image = Image.FromFile("icons/whatsapp.png");
            whatsappItem.Click += (s, ev) =>
            {
                string url = $"https://wa.me/?text={Uri.EscapeDataString(mensagem)}";
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            };

            // Item: Compartilhar por Email
            ToolStripMenuItem emailItem = new ToolStripMenuItem("Compartilhar por Email");
            emailItem.Image = Image.FromFile("icons/email.png");
            emailItem.Click += (s, ev) =>
            {
                string assunto = Uri.EscapeDataString("Versículo do Dia");
                string corpo = Uri.EscapeDataString(mensagem);
                string url = $"mailto:?subject={assunto}&body={corpo}";
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            };

            // Cria o item do menu
            ToolStripMenuItem salvarImagemItem = new ToolStripMenuItem("Salvar como Imagem");
            salvarImagemItem.Image = Image.FromFile("icons/image.png");

            // Define o evento Click
            salvarImagemItem.Click += (s, ev) =>
            {
                // Configura fonte e cores
                Font fonte = new Font("Segoe UI", 18, FontStyle.Bold);
                Color corFundo = Color.FromArgb(245, 245, 245);
                Color corTexto = Color.FromArgb(40, 40, 40);
                Color corSombra = Color.FromArgb(50, 0, 0, 0); // sombra preta semi-transparente

                // Calcula tamanho da imagem baseado no texto (com margem)
                int largura = 800;
                int margem = 30;
                SizeF tamanhoTexto;

                using (var bmpTmp = new Bitmap(1, 1))
                using (var gTmp = Graphics.FromImage(bmpTmp))
                {
                    var areaTexto = new RectangleF(0, 0, largura - 2 * margem, 1000);
                    var sf = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near };
                    tamanhoTexto = gTmp.MeasureString(mensagem, fonte, areaTexto.Size, sf);
                }

                int altura = (int)tamanhoTexto.Height + margem * 2;

                Bitmap bmp = new Bitmap(largura, altura);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.Clear(corFundo);

                    var areaTexto = new RectangleF(margem, margem, largura - 2 * margem, altura - 2 * margem);
                    var sf = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near };

                    // Desenha sombra do texto
                    using (Brush sombra = new SolidBrush(corSombra))
                    {
                        g.DrawString(mensagem, fonte, sombra, new RectangleF(areaTexto.X + 2, areaTexto.Y + 2, areaTexto.Width, areaTexto.Height), sf);
                    }

                    // Desenha texto principal
                    using (Brush bTexto = new SolidBrush(corTexto))
                    {
                        g.DrawString(mensagem, fonte, bTexto, areaTexto, sf);
                    }

                    // Linha decorativa na base
                    using (Pen pen = new Pen(Color.Orange, 3))
                    {
                        g.DrawLine(pen, margem, altura - margem / 2, largura - margem, altura - margem / 2);
                    }
                }

                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Imagem PNG|*.png",
                    FileName = "versiculo.png"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    bmp.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Imagem salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

          
            // Adiciona os itens ao menu
            menu.Items.Add(copiarItem);
            menu.Items.Add(whatsappItem);
            menu.Items.Add(emailItem);
            menu.Items.Add(salvarImagemItem);

            // Mostra o menu abaixo do botão
            menu.Show(btnCompartilharVersiculo, new Point(0, btnCompartilharVersiculo.Height));
        }

        private string ObterMensagemVersiculo()
        {
            string texto = Properties.Settings.Default.UltimoVersiculo;
            string referencia = Properties.Settings.Default.UltimaReferencia;

            if (string.IsNullOrWhiteSpace(texto) || string.IsNullOrWhiteSpace(referencia))
            {
                return null;
            }

            return $"\"{texto}\"\n— {referencia}";
        }

        private string ObterTextoVersiculo()
        {
            return Properties.Settings.Default.UltimoVersiculo; // só o texto
        }

        private string ObterReferenciaVersiculo()
        {
            return Properties.Settings.Default.UltimaReferencia; // só a referência tipo "Salmos 23:1"
        }


        // -------------------- RETORNAR AO ÚLTIMO VERSÍCULO --------------------

        private Label lblTituloUltimoPonto;
        private Label lblLivroCapitulo;

        private void CriarCardUltimoPonto()
        {
            cardUltimaLeitura.Controls.Clear();

            lblTituloUltimoPonto = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Text = "Última Leitura",
                Location = new Point(20, 20)
            };

            lblLivroCapitulo = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Text = "Nenhuma leitura registrada.",
                Location = new Point(20, 60)
            };


            // Adiciona ao card
            cardUltimaLeitura.Controls.Add(lblTituloUltimoPonto);
            cardUltimaLeitura.Controls.Add(lblLivroCapitulo);
            cardUltimaLeitura.Controls.Add(btnRetomarLeitura);
        }
        private void CarregarUltimoPonto()
        {
            var ponto = Versiculo.ObterUltimoPonto(Sessao.UserId);

            if (lblLivroCapitulo == null)
            {
                MessageBox.Show("lblLivroCapitulo é null!");
                return;
            }

            if (ponto.HasValue)
            {
                lblLivroCapitulo.Text = $"{ponto.Value.Livro} {ponto.Value.Capitulo}";
                btnRetomarLeitura.Enabled = true;
            }
            else
            {
                lblLivroCapitulo.Text = "Nenhuma leitura registrada.";
                btnRetomarLeitura.Enabled = false;
            }
        }

        private async void btnRetomarLeitura_Click(object sender, EventArgs e)
        {
            var ultimoPonto = Versiculo.ObterUltimoPonto(Sessao.UserId);

            if (ultimoPonto.HasValue)
            {

                string livro = ultimoPonto.Value.Livro;
                int capitulo = ultimoPonto.Value.Capitulo;

                // Atualizar os combo boxes para refletir o livro e capítulo
                cmbLivro.SelectedItem = livro;

                // Selecionar capítulo no combo
                cmbCapitulo.SelectedItem = capitulo.ToString();

                TabControlPrincipal.SelectedTab = tabBible;

                await BibleTab(livro, capitulo);
            }
            else
            {
                MessageBox.Show("Nenhum ponto de leitura encontrado.");
            }
        }

        // ------------------------------------------------------------------------------------
        // -------------------- TELA DAS ANOTAÇÕES DE UTILIZADOR ------------------------------
        // ------------------------------------------------------------------------------------

        private void cmbCategoriaAnotacoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoriaSelecionada = cmbCategoriaAnotacoes.SelectedItem.ToString();

            switch (categoriaSelecionada)
            {
                case "Anotações":
                    CarregarAnotacoes();
                    AtualizarLarguraDosCards(flowLayoutPanelAnotacoes);
                    AjustarFonteCards();
                    break;

                case "Grifos":
                    CarregarGrifos();
                    AtualizarLarguraDosCards(flowLayoutPanelAnotacoes);
                    AjustarFonteCards();
                    break;

                case "Versículos":
                    CarregarVersiculosDoDia();
                    AtualizarLarguraDosCards(flowLayoutPanelAnotacoes);
                    AjustarFonteCards();
                    break;
            }
        }

        private void CriarCardsAnotacoes(List<VersiculoAnotado> anotacoes, FlowLayoutPanel flowPanelAnotacoes)
        {
            pnlAnotacoes.ForeColor = Color.Red;
            flowPanelAnotacoes.Controls.Clear();

            flowPanelAnotacoes.Padding = new Padding(10, 50, 10, 10);

            foreach (var anotacao in anotacoes)
            {
                var card = new MaterialCard
                {
                    Padding = new Padding(10),
                    Margin = new Padding(10),
                    Width = flowPanelAnotacoes.ClientSize.Width - 30,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    Font = new Font("Segoe UI", 10),
                    Tag = anotacao
                };


                Label lblReferencia = new Label
                {
                    Text = $"{anotacao.Livro} {anotacao.Capitulo}:{anotacao.Versiculo} - {anotacao.DataSalvo.ToShortDateString()}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.LightBlue,
                    AutoSize = true
                };

                Label lblTexto = new Label
                {
                    Text = anotacao.Texto,
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.White,
                    MaximumSize = new Size(370, 0),
                    AutoSize = true,
                    Location = new Point(0, lblReferencia.Bottom + 5)
                };

                // Botão Editar
                Button btnEditar = new Button
                {
                    Text = "Editar",
                    AutoSize = true,
                    BackColor = Color.FromArgb(63, 81, 181),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(card.Width - 160, card.Height - 35),
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Right
                };

                // Botão Excluir
                Button btnExcluir = new Button
                {
                    Text = "Excluir",
                    AutoSize = true,
                    BackColor = Color.FromArgb(244, 67, 54),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(card.Width - 80, card.Height - 35),
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Right
                };

                btnEditar.Click += BtnEditar_Click;
                btnExcluir.Click += BtnExcluir_Click;

                card.Controls.Add(lblReferencia);
                card.Controls.Add(lblTexto);
                card.Controls.Add(btnEditar);
                card.Controls.Add(btnExcluir);

                flowPanelAnotacoes.Controls.Add(card);
            }
        }

        private void CarregarAnotacoes()
        {
            var anotacoes = Versiculo.ObterAnotacoes(Sessao.UserId);
            CriarCardsAnotacoes(anotacoes, flowLayoutPanelAnotacoes); // flowLayoutPanelAnotacoes dentro do tab "save"
        }

        private async void BtnEditar_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Parent is MaterialCard card)
            {
                // Aqui você precisa acessar os dados da anotação correspondente,

                if (card.Tag is VersiculoAnotado anotacao)
                {
                    using (var context = new Entities())
                    {
                        // Recarregar a anotação do banco para garantir estado atualizado
                        var anotacaoExistente = context.VersiculoAnotado
                            .FirstOrDefault(v => v.Id == anotacao.Id);

                        string textoAtual = anotacaoExistente?.Texto ?? "";
                        MenuForm menu = this.FindForm() as MenuForm; // ou passe como parâmetro

                        menu?.Hide();

                        using (FormAnotacao form = new FormAnotacao(textoAtual))
                        {
                            if (form.ShowDialog(this) == DialogResult.OK)
                            {
                                if (anotacaoExistente != null)
                                {
                                    anotacaoExistente.Texto = form.TextoAnotacao;
                                }
                                else
                                {
                                    // Pode criar nova anotação aqui se quiser (normalmente não no editar)
                                }

                                context.SaveChanges();
                            }
                        }
                        menu?.Show();
                    }

                    await AtualizarInterfaceCompletaAsync();

                }
            }
        }

        private async void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Parent is MaterialCard card)
            {
                // Supondo que o objeto VersiculoAnotado esteja na Tag do card
                if (card.Tag is VersiculoAnotado anotacao)
                {
                    var confirmResult = MessageBox.Show(
                        "Tem certeza que deseja excluir esta anotação?",
                        "Confirmar Exclusão",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirmResult == DialogResult.Yes)
                    {
                        using (var context = new Entities())
                        {
                            var anotacaoExistente = context.VersiculoAnotado
                                .FirstOrDefault(v => v.Id == anotacao.Id);

                            if (anotacaoExistente != null)
                            {
                                context.VersiculoAnotado.Remove(anotacaoExistente);
                                context.SaveChanges();

                                // remover o card da interface
                                var parent = card.Parent;
                                parent?.Controls.Remove(card);

                                MessageBox.Show("Anotação excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Anotação não encontrada na base de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        // ------------------------------------------------------------------------------------
        // -------------------- TELA DOS GRIFOS SALVOS --------------------------------------
        // ------------------------------------------------------------------------------------
        private void CriarCardsGrifos(List<VersiculoSublinhado> grifos, FlowLayoutPanel flowPanelAnotacoes)
        {
            flowPanelAnotacoes.Controls.Clear();
            flowPanelAnotacoes.Padding = new Padding(10, 50, 10, 10);

            foreach (var grifo in grifos)
            {
                var card = new MaterialCard
                {
                    Padding = new Padding(10),
                    Margin = new Padding(10),
                    Width = flowPanelAnotacoes.ClientSize.Width - 30,
                    AutoSize = false,
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    Font = new Font("Segoe UI", 10),
                    Tag = grifo
                };

                Label lblReferencia = new Label
                {
                    Text = $"{grifo.Livro} {grifo.Capitulo}:{grifo.Versiculo} - {grifo.DataCriado?.ToShortDateString()}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.LightBlue,
                    AutoSize = true
                };

                Label lblTexto = new Label
                {
                    Text = grifo.Texto,
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.White,
                    AutoSize = false,
                    Width = card.Width - 150,
                    Height = 60, // altura limitada para mostrar só parte do texto
                    AutoEllipsis = true, // ativa os "..."
                    Cursor = Cursors.Hand,
                    Location = new Point(0, lblReferencia.Bottom + 5),
                    Tag = grifo
                };

                Button btnExcluirGrifo = new Button
                {
                    Text = "Excluir",
                    AutoSize = true,
                    BackColor = Color.FromArgb(244, 67, 54),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(card.Width - 80, card.Height - 35),
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Right
                };

                btnExcluirGrifo.Click += (s, e) =>
                {
                    var resultado = MessageBox.Show("Deseja realmente excluir este grifo?", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (resultado == DialogResult.Yes)
                    {
                        var grifoExcluir = (VersiculoSublinhado)card.Tag;

                        Versiculo.ExcluirGrifo(grifoExcluir.UserId, grifoExcluir.Livro, grifoExcluir.Capitulo, grifoExcluir.Versiculo);
                        flowPanelAnotacoes.Controls.Remove(card);

                        MostrarSnackbar("Grifo excluído com sucesso!");
                    }
                };

                var corGrifo = ColorTranslator.FromHtml(grifo.Cor ?? "#FFFFFF");

                Panel indicadorCor = new Panel
                {
                    Size = new Size(16, 16),
                    BackColor = corGrifo,
                    Margin = new Padding(0)
                };

                card.Resize += (s, e) =>
                {
                    indicadorCor.Location = new Point(card.Width - indicadorCor.Width - 10, 10);
                };

                // Garante a posição inicial
                indicadorCor.Location = new Point(card.Width - indicadorCor.Width - 10, 10);

                card.Controls.Add(lblReferencia);
                card.Controls.Add(lblTexto);
                card.Controls.Add(indicadorCor);
                card.Controls.Add(btnExcluirGrifo);

                lblTexto.MouseClick += VersiculoGrifadoClicado;

                flowPanelAnotacoes.Controls.Add(card);
            }

            flowPanelAnotacoes.Controls.Add(new Panel
            {
                Height = 50,
                Width = 0,
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            });
        }

        private void MostrarSnackbar(string mensagem)
        {
            Label snackbar = new Label
            {
                Text = mensagem,
                BackColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                Height = 30,
                Font = new Font("Segoe UI", 13, FontStyle.Regular)
            };

            this.Controls.Add(snackbar);
            snackbar.BringToFront();

            var timer = new Timer();
            timer.Interval = 2500; // 2,5 segundos
            timer.Tick += (s, e) =>
            {
                this.Controls.Remove(snackbar);
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private async void VersiculoGrifadoClicado(object sender, MouseEventArgs e)
        {
            if (sender is Label lbl && lbl.Tag is VersiculoSublinhado grifo)
            {
                lbl.Font = new Font(lbl.Font, lbl.Font.Style | FontStyle.Underline);

                ContextMenuStrip menu = new ContextMenuStrip();

                ToolStripMenuItem lerItem = new ToolStripMenuItem("Abrir na Bíblia")
                {
                    Image = Image.FromFile("icons/book-open-text.png")
                };
                lerItem.Click += async (s, ev) =>
                {
                    string livro = grifo.Livro;
                    int capitulo = grifo.Capitulo;

                    cmbLivro.SelectedItem = livro;
                    cmbCapitulo.SelectedItem = capitulo.ToString();
                    TabControlPrincipal.SelectedTab = tabBible;

                    await BibleTab(livro, capitulo);
                };

                menu.Items.Add(lerItem);

                menu.Closed += (s, ev) =>
                {
                    lbl.Font = new Font(lbl.Font, lbl.Font.Style & ~FontStyle.Underline);
                };

                menu.Show(lbl, new Point(e.X, e.Y));
            }
        }


        private void CarregarGrifos()
        {
            var grifos = Versiculo.ObterGrifosUtilizador(Sessao.UserId);
            CriarCardsGrifos(grifos, flowLayoutPanelAnotacoes);
        }

        // ------------------------------------------------------------------------------------
        // -------------------- TELA DOS VERSÍCULOS SALVOS --------------------------------------
        // ------------------------------------------------------------------------------------

        private async void VersiculoSalvoClicado(object sender, MouseEventArgs e)
        {
            if (sender is Label lbl && lbl.Tag is VersiculoSalvo grifo)
            {
                lbl.Font = new Font(lbl.Font, lbl.Font.Style | FontStyle.Underline);

                ContextMenuStrip menu = new ContextMenuStrip();

                ToolStripMenuItem lerItem = new ToolStripMenuItem("Abrir na Bíblia")
                {
                    Image = Image.FromFile("icons/book-open-text.png")
                };
                lerItem.Click += async (s, ev) =>
                {
                    string livro = grifo.Livro;
                    int capitulo = grifo.Capitulo;

                    cmbLivro.SelectedItem = livro;
                    cmbCapitulo.SelectedItem = capitulo.ToString();
                    TabControlPrincipal.SelectedTab = tabBible;

                    await BibleTab(livro, capitulo);
                };

                menu.Items.Add(lerItem);

                menu.Closed += (s, ev) =>
                {
                    lbl.Font = new Font(lbl.Font, lbl.Font.Style & ~FontStyle.Underline);
                };

                menu.Show(lbl, new Point(e.X, e.Y));
            }
        }

        private void CriarCardsVersiculos(List<VersiculoSalvo> versiculos, FlowLayoutPanel flowPanelAnotacoes)
        {
            flowPanelAnotacoes.Controls.Clear();
            flowPanelAnotacoes.Padding = new Padding(10, 50, 10, 10);

            foreach (var versiculo in versiculos)
            {
                var card = new MaterialCard
                {
                    Padding = new Padding(10),
                    Margin = new Padding(10),
                    Width = flowPanelAnotacoes.ClientSize.Width - 30,
                    AutoSize = false,
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    Font = new Font("Segoe UI", 10),
                    Tag = versiculo
                };

                Label lblReferencia = new Label
                {
                    Text = $"{versiculo.Livro} {versiculo.Capitulo}:{versiculo.Versiculo} - {versiculo.DataSalvo.ToShortDateString()}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.LightBlue,
                    AutoSize = true
                };

                Label lblTexto = new Label
                {
                    Text = versiculo.Texto,
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.White,
                    MaximumSize = new Size(370, 0),
                    AutoSize = false,
                    Width = card.Width - 150,
                    Height = 60,
                    AutoEllipsis = true,
                    Cursor = Cursors.Hand,
                    Location = new Point(0, lblReferencia.Bottom + 5),
                    Tag = versiculo
                };

                Button btnExcluirVersiculo = new Button
                {
                    Text = "Excluir",
                    AutoSize = true,
                    BackColor = Color.FromArgb(244, 67, 54),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(card.Width - 80, card.Height - 35),
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Right
                };

                btnExcluirVersiculo.Click += (s, e) =>
                {
                    var resultado = MessageBox.Show("Deseja realmente excluir este versículo?", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (resultado == DialogResult.Yes)
                    {
                        var versiculoExcluir = (VersiculoSalvo)card.Tag;

                        Versiculo.ExcluirVersiculoSalvo(versiculoExcluir.UserId, versiculoExcluir.Livro, versiculoExcluir.Capitulo, versiculoExcluir.Versiculo);
                        flowPanelAnotacoes.Controls.Remove(card);

                        MostrarSnackbar("Versículo excluído com sucesso!");
                    }
                };

                card.Controls.Add(lblReferencia);
                card.Controls.Add(lblTexto);
                card.Controls.Add(btnExcluirVersiculo);

                lblTexto.MouseClick += VersiculoSalvoClicado;

                flowPanelAnotacoes.Controls.Add(card);
            }

            flowPanelAnotacoes.Controls.Add(new Panel
            {
                Height = 50,
                Width = 0,
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            });
        }
        private void CarregarVersiculosDoDia()
        {
            var versiculos = Versiculo.ObterVersiculosSalvos(Sessao.UserId);
            CriarCardsVersiculos(versiculos, flowLayoutPanelAnotacoes); // flowLayoutPanelAnotacoes dentro do tab "save"
        }

        // ------------------------------------------------------------------------------------
        // -------------------- TELA DE TODOS OS PLANOS ---------------------------------------
        // ------------------------------------------------------------------------------------

        private void cmbCategoriaPlanos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoriaSelecionada = cmbCategoriaPlanos.SelectedItem.ToString();

            switch (categoriaSelecionada)
            {
                case "Todos":
                    CarregarPlanoLeituraTodos();
                    AtualizarLarguraDosCards(flowPanelPlanos); //Responsivo
                    AjustarFonteCards(); //Responsivo
                    break;

                case "Meus":
                    CarregarMeusPlanos(); // você também cria essa função
                    AtualizarLarguraDosCards(flowPanelPlanos); //Responsivo
                    AjustarFonteCards(); //Responsivo
                    break;
            }
        }

        private void CriarCardsPlanoLeitura(List<PlanoLeitura> planos, FlowLayoutPanel flowPanelPlanos)
        {
            flowPanelPlanos.Controls.Clear();
            flowPanelPlanos.Padding = new Padding(10, 20, 10, 10);

            foreach (var plano in planos)
            {
                // Card
                var card = new MaterialCard
                {
                    Padding = new Padding(10),
                    Margin = new Padding(10),
                    Width = flowPanelPlanos.ClientSize.Width - 30,
                    Height = 120,
                    AutoSize = false,
                    BackColor = Color.White,
                    Tag = plano
                };

                // Imagem (ícone)
                var pic = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(10, 10),
                    Size = new Size(80, 80)
                };

                if (!string.IsNullOrEmpty(plano.ImagemBase64))
                {
                    try
                    {
                        byte[] imageBytes = Convert.FromBase64String(plano.ImagemBase64);
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            pic.Image = Image.FromStream(ms);
                        }
                    }
                    catch
                    {
                        // Caso a imagem esteja malformada ou ausente, usa-se uma imagem padrão
                        pic.Image = Properties.Resources.ImagemPadrao;
                    }
                }
                else
                {
                    pic.Image = Properties.Resources.ImagemPadrao;
                }

                card.Controls.Add(pic);

                // Título
                var lblTitulo = new Label
                {
                    Text = plano.Nome,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(100, 10),
                    AutoSize = true
                };
                card.Controls.Add(lblTitulo);

                // Descrição
                var lblDescricao = new Label
                {
                    Text = plano.Descricao,
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.White,
                    Location = new Point(100, 35),
                    Size = new Size(card.Width - 200, 40),
                    AutoEllipsis = true
                };
                card.Controls.Add(lblDescricao);

                // Botão "Iniciar"
                var btnIniciar = new MaterialButton
                {
                    Text = "Iniciar",
                    AutoSize = true,
                    BackColor = Color.FromArgb(244, 67, 54),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(card.Width - 80, card.Height - 45),
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                    Tag = plano // você pode usar isso pra abrir nova tela ou iniciar o plano
                };

                // Evento de clique (opcional)
                btnIniciar.Click += (sender, e) =>
                {
                    var planoSelecionado = (PlanoLeitura)((MaterialButton)sender).Tag;

                    using (var db = new Entities())
                    {
                        // Verifica se o usuário já iniciou esse plano
                        int userId = Sessao.UserId; // Substitua isso pelo seu sistema de login

                        bool jaIniciado = db.PlanoLeituraUtilizador
                                            .Any(p => p.UserId == userId && p.PlanoLeituraId == planoSelecionado.Id);

                        if (jaIniciado)
                        {
                            MessageBox.Show("Você já iniciou esse plano.");
                            return;
                        }

                        // Cria o registro de PlanoLeituraUtilizador
                        var planoUtil = new PlanoLeituraUtilizador
                        {
                            UserId = userId,
                            PlanoLeituraId = planoSelecionado.Id,
                            DataInicio = DateTime.Today,
                            ProgressoDiaAtual = 1
                        };

                        db.PlanoLeituraUtilizador.Add(planoUtil);
                        db.SaveChanges();

                        // Pega o ID gerado
                        int planoUtilId = planoUtil.Id;

                        // Copia os dias do modelo
                        var diasModelo = db.PlanoLeituraModeloDia
                                           .Where(d => d.PlanoLeituraId == planoSelecionado.Id)
                                           .OrderBy(d => d.Dia)
                                           .ToList();

                        foreach (var diaModelo in diasModelo)
                        {
                            var novoDia = new PlanoLeituraDia
                            {
                                PlanoUtilizadorId = planoUtilId,
                                Dia = diaModelo.Dia,
                                Capitulos = diaModelo.Capitulos,
                                Lido = false,
                                DataLeitura = null
                            };
                            db.PlanoLeituraDia.Add(novoDia);
                        }

                        db.SaveChanges();
                    }

                    MessageBox.Show("Plano iniciado com sucesso!");
                    // Opcional: atualizar a tela ou abrir a leitura
                    // var formLeitura = new FormLeituraDiaria(planoUtil.Id);
                    // formLeitura.Show();
                };

                card.Controls.Add(btnIniciar);

                flowPanelPlanos.Controls.Add(card);
            }
        }

        private void CarregarPlanoLeituraTodos()
        {
            using (var context = new Entities())
            {
                var planos = context.PlanoLeitura.ToList();
                CriarCardsPlanoLeitura(planos, flowPanelPlanos);
            }
        }

        private void CriarCardsMeusPlanos(List<PlanoLeituraUtilizador> planos, FlowLayoutPanel flowPanelPlanos)
        {
            flowPanelPlanos.Controls.Clear();

            using (var db = new Entities())
            {
                foreach (var planoUtilizador in planos)
                {
                    var plano = planoUtilizador.PlanoLeitura;

                    var card = new MaterialCard
                    {
                        Padding = new Padding(10),
                        Margin = new Padding(10),
                        Width = flowPanelPlanos.ClientSize.Width - 30,
                        Height = 150,
                        BackColor = Color.White
                    };

                    // Imagem
                    var pic = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Location = new Point(10, 10),
                        Size = new Size(80, 80)
                    };

                    if (!string.IsNullOrEmpty(plano.ImagemBase64))
                    {
                        byte[] imgBytes = Convert.FromBase64String(plano.ImagemBase64);
                        pic.Image = Image.FromStream(new MemoryStream(imgBytes));
                    }

                    card.Controls.Add(pic);

                    // Título
                    var lblTitulo = new Label
                    {
                        Text = plano.Nome,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        ForeColor = Color.White,
                        Location = new Point(100, 10),
                        AutoSize = true
                    };
                    card.Controls.Add(lblTitulo);

                    int totalDias = plano.DiasDuracao;
                    if (totalDias <= 0) totalDias = 1;

                    int progressoBruto = (int)planoUtilizador.ProgressoDiaAtual;
                    int progressoDia = progressoBruto - 1;
                    if (progressoDia < 0) progressoDia = 0;

                    // Verifica se o dia atual foi lido
                    var leituraAtual = db.PlanoLeituraDia
                        .FirstOrDefault(d => d.PlanoUtilizadorId == planoUtilizador.Id && d.Dia == progressoBruto);

                    if (leituraAtual?.Lido == true)
                    {
                        progressoDia++;
                    }

                    bool planoConcluido = progressoDia >= totalDias;
                    int porcentagem = planoConcluido ? 100 : (int)((progressoDia / (double)totalDias) * 100);

                    // Remove barras antigas, se existirem
                    var barrasExistentes = card.Controls.OfType<ProgressBar>().ToList();
                    foreach (var b in barrasExistentes)
                    {
                        card.Controls.Remove(b);
                        b.Dispose();
                    }

                    var barra = new ProgressBar
                    {
                        Minimum = 0,
                        Maximum = 100,
                        Value = Math.Min(Math.Max(porcentagem, 0), 100),
                        Size = new Size(card.Width - 120, 20),
                        Location = new Point(100, 40)
                    };

                    card.Controls.Add(barra);
                    barra.BringToFront();

                    var lblProgresso = new Label
                    {
                        Text = planoConcluido ? $"Plano concluído ({totalDias} dias)" : $"Dia {progressoBruto} de {totalDias}",
                        Location = new Point(100, 65),
                        AutoSize = true
                    };

                    card.Controls.Add(lblProgresso);

                    var btnContinuar = new MaterialButton
                    {
                        AutoSize = true,
                        BackColor = planoConcluido ? Color.Gray : Color.FromArgb(244, 67, 54),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Location = new Point(card.Width - 80, card.Height - 45),
                        Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                        Tag = planoUtilizador
                    };

                    if (planoConcluido)
                    {
                        btnContinuar.Text = "Concluído ✔";
                        btnContinuar.Enabled = false;
                    }
                    else
                    {
                        btnContinuar.Text = "Continuar";
                        btnContinuar.Click += BtnContinuar_Click;
                    }

                    card.Controls.Add(btnContinuar);

                    flowPanelPlanos.Controls.Add(card);
                }
            }
        }

        private async void BtnContinuar_Click(object sender, EventArgs e)
        {
            var btn = sender as MaterialButton;
            var planoUtilizador = btn?.Tag as PlanoLeituraUtilizador;

            if (planoUtilizador == null)
                return;

            int diaAtual = (int)planoUtilizador.ProgressoDiaAtual;
            int totalDias = planoUtilizador.PlanoLeitura.DiasDuracao;

            // Só impede se já passou do total de dias
            if (diaAtual > totalDias)
            {
                MessageBox.Show("Este plano já foi concluído! 🎉", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Abre a tela de leitura diária
            var leituraForm = new FormLeituraDiaria(planoUtilizador.Id);
            leituraForm.ShowDialog();

            // Após o diálogo ser fechado, atualiza toda a interface
            await AtualizarInterfaceCompletaAsync();
        }



        private void CarregarMeusPlanos()
        {
            int userId = Sessao.UserId;

            using (var context = new Entities())
            {
                var meusPlanos = context.PlanoLeituraUtilizador
                    .Where(pu => pu.UserId == userId)
                    .Include(pu => pu.PlanoLeitura)
                    .ToList();

                CriarCardsMeusPlanos(meusPlanos, flowPanelPlanos);
            }
        }

        // ------------------------------------------------------------------------------------
        // -------------------- TELA DAS DEFINIÇÕES ---------------------------------------
        // ------------------------------------------------------------------------------------

        private void CriarPainelDeConfiguracoes(Panel panelSettings)
        {
            panelSettings.AutoScroll = true;
            panelSettings.Dock = DockStyle.Fill;
            panelSettings.Padding = new Padding(10);
            panelSettings.Controls.Clear(); // limpa antes de adicionar

            cmbFonte.Items.Clear();
            foreach (FontFamily fonte in FontFamily.Families)
            {
                cmbFonte.Items.Add(fonte.Name);
            }

            // Adiciona os grupos ao painel
            panelSettings.Controls.Add(gbFonteTamanho);
            panelSettings.Controls.Add(gbSessao);
        }

        private void SwitchManterSessao_CheckedChanged(object sender, EventArgs e)
        {
            if (SwitchManterSessao.Checked)
            {
                Properties.Settings.Default.ManterSessao = true;
                Properties.Settings.Default.UsernameSalvo = Sessao.Username;
                Properties.Settings.Default.UserIdSalvo = Sessao.UserId;
            }
            else
            {
                Properties.Settings.Default.ManterSessao = false;
                Properties.Settings.Default.UsernameSalvo = "";
                Properties.Settings.Default.UserIdSalvo = 0;
            }

            Properties.Settings.Default.Save();
        }

        private async void switchTema_CheckedChanged(object sender, EventArgs e)
        {
            var skinManager = MaterialSkinManager.Instance;

            if (switchTema.Checked)
            {
                skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            else
            {
                skinManager.Theme = MaterialSkinManager.Themes.DARK;
            }

            // Atualiza o esquema de cores se quiser (opcional)
            skinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey500,
                Primary.BlueGrey700,
                Primary.BlueGrey100,
                Accent.DeepOrange200,
                switchTema.Checked ? TextShade.WHITE : TextShade.BLACK
            );

            await AtualizarInterfaceCompletaAsync();

        }

    }
}
