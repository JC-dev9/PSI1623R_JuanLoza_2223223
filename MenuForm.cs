// -------------------- IMPORTAÇÕES --------------------
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


namespace BeLightBible
{
    public partial class MenuForm : MaterialForm
    {
        // -------------------- VARIÁVEIS --------------------
        private static readonly HttpClient client = new HttpClient();
        private PictureBox picLoading;
        private Label lblTituloCapitulo;
        private Label lblNumeroVersiculo;
        private Livro livros = new Livro();
        private Estilo estilo = new Estilo();
        private readonly ApiBibleService bibleService = new ApiBibleService();
        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private bool isPlaying = false;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeft, int nTop, int nRight, int nBottom, int nWidthEllipse, int nHeightEllipse);


        // -------------------- CONSTRUTOR --------------------
        public MenuForm()
        {
            InitializeComponent();
            CarregarLivros();


            // Inicialização do PictureBox de loading
            picLoading = new PictureBox
            {
                Size = new Size(48, 48),
                ImageLocation = "loading.gif",
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(this.ClientSize.Width / 2 - 24, this.ClientSize.Height / 2 - 24),
                Visible = false,
                BackColor = Color.Transparent
            };

            Label lblTituloCapitulo = new Label
            {
                AutoSize = true, // Vai se ajustar ao texto
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White, // Cor do texto
                BackColor = Color.Transparent, // Fundo transparente se estiver sobre uma imagem ou painel colorido
                Margin = new Padding(5), // Espaçamento externo
                Padding = new Padding(2), // Espaçamento interno
                Location = new Point(flowLayoutPanelVersiculos.Left, flowLayoutPanelVersiculos.Top),
                Text = $"Versículo do dia dia"
            };


            this.Controls.Add(picLoading);
            picLoading.BringToFront();

            // Configurações do flowLayoutPanel dos Versiculos
            flowLayoutPanelVersiculos.Dock = DockStyle.Fill;
            flowLayoutPanelVersiculos.AutoScroll = true;
            flowLayoutPanelVersiculos.WrapContents = false;
            flowLayoutPanelVersiculos.FlowDirection = FlowDirection.TopDown;

            // Configura flowLayoutPanelConversa (se não configurado no Designer)
            flowLayoutPanelConversa.Padding = new Padding(0, 0, 0, 70); // ajusta conforme altura do painel inferior

            flowLayoutPanelConversa.Dock = DockStyle.Fill;
            flowLayoutPanelConversa.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelConversa.WrapContents = false;
            flowLayoutPanelConversa.AutoScroll = true;


            // Configurações do FlowLayoutPanel das anotações de versículos
            flowLayoutPanelAnotacoes.Dock = DockStyle.Fill;
            flowLayoutPanelAnotacoes.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelAnotacoes.WrapContents = false;
            flowLayoutPanelAnotacoes.AutoScroll = true;


            // Âncoras
            cmbLivro.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            cmbCapitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left;


            // Skin do MaterialSkin
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

            cmbLivro.SelectedIndexChanged += cmbLivro_SelectedIndexChanged;

            // Estilização dos botões e controles
            estilo.EstilizarPictureBoxComoBotao(picBtnProximoCapitulo, true, cmbLivro, cmbCapitulo, BibleTab);
            estilo.EstilizarPictureBoxComoBotao(picBtnAnteriorCapitulo, false, cmbLivro, cmbCapitulo, BibleTab);
            estilo.EstilizarPictureBoxAudio(picAudio);

            estilo.ArredondarControle(picBtnProximoCapitulo, 10);
            estilo.ArredondarControle(picBtnAnteriorCapitulo, 10);
            estilo.ArredondarControle(picAudio, 10);

            this.Load += MenuForm_Load;

            this.Resize += MenuForm_Resize;
            this.Resize += (s, e) =>
            {
                AtualizarLarguraDosCards();
                AjustarFonteCards();
            };

            flowLayoutPanelConversa.Resize += flowLayoutPanelConversa_Resize;
            AplicarLayoutResponsivoBible();
            AtualizarLarguraDasMensagens();
        }

        // -------------------- LAYOUT --------------------
        private void MenuForm_Resize(object sender, EventArgs e)
        {
            AplicarLayoutResponsivoBible();
            AtualizarLarguraDasMensagens();
        }

        private async void MenuForm_Load(object sender, EventArgs e)
        {
            CriarCardUltimoPonto();
            CarregarUltimoPonto();
            CriarLabelsVersiculoDia();
            await CarregarVersiculoDiaAsync(); // Carrega o versículo do dia na tela inicial

            CarregarAnotacoes();

        }

        private void AtualizarLarguraDosCards()
        {
            foreach (Control control in flowLayoutPanelAnotacoes.Controls)
            {
                if (control is MaterialCard card)
                {
                    card.Width = flowLayoutPanelAnotacoes.ClientSize.Width - 30;
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
            float fontSizeReferencia = Math.Min(Math.Max(8f, baseFontSizeReferencia * scaleFactor), 16f);
            float fontSizeTexto = Math.Min(Math.Max(9f, baseFontSizeTexto * scaleFactor), 18f);
            float fontSizeBtn = Math.Min(Math.Max(7f, baseFontSizeBtn * scaleFactor), 14f);

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
                        else if (child is Button btn)
                        {
                            btn.Font = new Font("Segoe UI", fontSizeBtn, FontStyle.Regular);
                        }
                    }
                }
            }
        }


        private void AdicionarEspacadorFinal()
        {
            // Remove se já houver
            var existente = flowLayoutPanelConversa.Controls.Cast<Control>().FirstOrDefault(c => c.Tag?.ToString() == "EspacadorFinal");
            if (existente != null)
                flowLayoutPanelConversa.Controls.Remove(existente);

            // Cria um painel com altura do espaço desejado
            var espaco = new Panel()
            {
                Height = txtPergunta.Height + btnEnviarChatbot.Height + 20, // espaço extra para evitar sobreposição
                Width = flowLayoutPanelConversa.ClientSize.Width,
                Tag = "EspacadorFinal",
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            };

            flowLayoutPanelConversa.Controls.Add(espaco);
            flowLayoutPanelConversa.ScrollControlIntoView(espaco);
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
                Margin = new Padding(5),
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

        private async Task EnviarParaOllama(string pergunta)
        {
            try
            {
                var url = "http://localhost:11434/api/generate";

                var promptEspecializado =

      "Responda com base na Bíblia Sagrada, de forma clara, fiel e acessível, como um teólogo experiente. " +
      "Não faça saudações ou introduções; responda diretamente à pergunta.\n\n" +
      $"Pergunta do utilizador:\n{pergunta}\n\n" +
      "Resposta:";


                var requestData = new
                {
                    model = "gemma3:4b-it-qat",
                    prompt = promptEspecializado,
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

                // Adiciona bolha vazia e atualiza em tempo real
                var botBubble = CreateMessageBubble("", false);
                var botLabel = (Label)botBubble.Controls[0];
                flowLayoutPanelConversa.Controls.Add(botBubble);
                flowLayoutPanelConversa.ScrollControlIntoView(botBubble);

                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // Remove prefixo "data: "
                    if (line.StartsWith("data: ")) line = line.Substring(6);

                    dynamic obj = JsonConvert.DeserializeObject(line);
                    string contentPart = obj?.response;
                    if (contentPart != null)
                    {
                        botLabel.Text += contentPart;
                        botBubble.Width = botLabel.PreferredWidth + 20;
                        Application.DoEvents();
                    }
                }
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

        private async void MensagemClicada(object sender, MouseEventArgs e)
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

        // -------------------- CARREGAMENTO --------------------
        private void CarregarLivros()
        {
            var livrosDictionary = livros.ObterLivros();

            foreach (var livro in livrosDictionary)
            {
                cmbLivro.Items.Add(livro.Key);
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

            lblTituloCapitulo = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
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
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
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
                cmbCapitulo.SelectedIndex = 0;
        }

        private async void VersiculoClicado(object sender, MouseEventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.Font = new Font(lbl.Font, lbl.Font.Style | FontStyle.Underline);
                Versiculo versiculo = new Versiculo(lbl);

                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add(new ToolStripMenuItem("Grifar", Image.FromFile("icons/palette.png"), (s, ev) =>
                {
                    int versNumero = Convert.ToInt32(lbl.Tag);
                    versiculo.Grifar(Sessao.UserId, cmbLivro.SelectedItem.ToString(), int.Parse(cmbCapitulo.SelectedItem.ToString()), versNumero);
                }));
                menu.Items.Add(new ToolStripMenuItem("Copiar", Image.FromFile("icons/copy.png"), (s, ev) => versiculo.Copiar()));
                menu.Items.Add(new ToolStripMenuItem("Anotar", Image.FromFile("icons/notepad.png"), async (s, ev) =>
                {
                    int versNumero = Convert.ToInt32(lbl.Tag);
                    await versiculo.Anotar(Sessao.UserId, cmbLivro.SelectedItem.ToString(), int.Parse(cmbCapitulo.SelectedItem.ToString()), versNumero,
                        async () => await BibleTab(cmbLivro.SelectedItem.ToString(), int.Parse(cmbCapitulo.SelectedItem.ToString())));

                    estilo.EstilizarPictureBoxComoBotao(picBtnProximoCapitulo, true, cmbLivro, cmbCapitulo, BibleTab);
                    estilo.EstilizarPictureBoxComoBotao(picBtnAnteriorCapitulo, false, cmbLivro, cmbCapitulo, BibleTab);
                    estilo.EstilizarPictureBoxAudio(picAudio);

                    estilo.ArredondarControle(picBtnProximoCapitulo, 10);
                    estilo.ArredondarControle(picBtnAnteriorCapitulo, 10);
                    estilo.ArredondarControle(picAudio, 10);

                }));
                menu.Items.Add(new ToolStripMenuItem("Explicar", Image.FromFile("icons/ai.png"), async (s, ev) =>
                {
                    int versNumero = Convert.ToInt32(lbl.Tag);
                    string livro = cmbLivro.SelectedItem.ToString();
                    int capitulo = int.Parse(cmbCapitulo.SelectedItem.ToString());

                    // Muda para a aba do chatbot
                    TabControlPrincipal.SelectedTab = tabChatbot;

                    // Cria o prompt
                    string prompt = $"Você é um especialista bíblico. Explique com clareza e profundidade o contexto histórico, cultural e teológico do versículo {livro} {capitulo}:{versiculo}. Inclua referências relevantes e aplicação prática para a vida cristã hoje.";


                    // Mostra a mensagem do usuário na conversa
                    AddUserMessage(prompt);

                    // Envia o prompt para o chatbot (aguarda resposta)
                    await EnviarParaOllama(prompt);
                }));

                menu.Items.Add(new ToolStripMenuItem("Compartilhar", Image.FromFile("icons/share-2.png"), (s, ev) => versiculo.Copiar()));

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
            new LoginForm().Show();
            this.Hide();
        }

        private void tabPage4_Click(object sender, EventArgs e) { }

        // -------------------- ÁUDIO --------------------
        private void picAudio_Click(object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                string texto = ObterTextoDosVersiculos();

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    synthesizer.SpeakCompleted += Synthesizer_SpeakCompleted;
                    synthesizer.SpeakAsyncCancelAll();
                    synthesizer.SpeakAsync(texto);

                    picAudio.Image = Image.FromFile("pause.png");
                    isPlaying = true;
                }
            }
            else
            {
                synthesizer.SpeakAsyncCancelAll();
                picAudio.Image = Image.FromFile("volume-2-white.png");
                isPlaying = false;
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
            }
            else
            {
                lblTextoVersiculo.Text = "Não foi possível carregar o versículo do dia.";
            }
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

            // Item: Salvar Imagem
            ToolStripMenuItem salvarImagemItem = new ToolStripMenuItem("Salvar como Imagem");
            salvarImagemItem.Image = Image.FromFile("icons/image.png");
            salvarImagemItem.Click += (s, ev) =>
            {
                Bitmap bmp = new Bitmap(600, 200); // ajuste tamanho
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    g.DrawString(mensagem, new Font("Arial", 16), Brushes.Black, new RectangleF(10, 10, 580, 180));
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

            // Item: Salvar Versículo em PDF
            ToolStripMenuItem salvarPdfItem = new ToolStripMenuItem("Salvar como PDF");
            salvarPdfItem.Image = Image.FromFile("icons/pdf.png");
            salvarPdfItem.Click += (s, ev) =>
            {
                string texto = ObterTextoVersiculo();
                string referencia = ObterReferenciaVersiculo();

                if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(referencia))
                {
                    MessageBox.Show("Nenhum versículo para salvar.");
                    return;
                }

                try
                {
                    string[] partes = referencia.Split(' ');
                    string livro = partes[0];
                    string[] capVers = partes[1].Split(':');
                    int capitulo = int.Parse(capVers[0]);
                    int versiculo = int.Parse(capVers[1]);

                    // Chama a função que gera o PDF (que abre o SaveFileDialog)
                    Versiculo.SalvarVersiculoComoPdf(texto, livro, capitulo, versiculo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Formato da referência inválido: " + ex.Message);
                }

            };



            // Adiciona os itens ao menu
            menu.Items.Add(copiarItem);
            menu.Items.Add(whatsappItem);
            menu.Items.Add(emailItem);
            menu.Items.Add(salvarPdfItem);
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

        private void CriarCardsAnotacoes(List<VersiculoAnotado> anotacoes, FlowLayoutPanel flowPanelAnotacoes)
        {
            flowPanelAnotacoes.Controls.Clear();

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
                    MaximumSize = new Size(card.Width - 20, 0),
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

                // Adiciona ações (event handlers) — você pode ajustar:
                btnEditar.Click += (s, e) =>
                {
                    // Lógica para editar
                };

                btnExcluir.Click += (s, e) =>
                {
                    // Lógica para excluir
                };


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




    }
}
