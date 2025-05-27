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

namespace BeLightBible
{
    public partial class MenuForm : MaterialForm
    {
        // -------------------- VARIÁVEIS --------------------
        private static readonly HttpClient client = new HttpClient();
        private PictureBox picLoading;
        private Livro livros = new Livro();
        private Estilo estilo = new Estilo();
        private Label lblTituloCapitulo;
        private readonly ApiBibleService bibleService = new ApiBibleService();
        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private bool isPlaying = false;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeft, int nTop, int nRight, int nBottom, int nWidthEllipse, int nHeightEllipse);


        // -------------------- CONSTRUTOR --------------------
        public MenuForm()
        {
            InitializeComponent();

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

            this.Controls.Add(picLoading);
            picLoading.BringToFront();

            // Configurações do flowLayoutPanel dos Versiculos
            flowLayoutPanelVersiculos.Dock = DockStyle.Fill;
            flowLayoutPanelVersiculos.AutoScroll = true;
            flowLayoutPanelVersiculos.WrapContents = false;
            flowLayoutPanelVersiculos.FlowDirection = FlowDirection.TopDown;

            // Configura flowLayoutPanelConversa (se não configurado no Designer)
            flowLayoutPanelConversa.Dock = DockStyle.Fill;
            flowLayoutPanelConversa.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelConversa.WrapContents = false;
            flowLayoutPanelConversa.AutoScroll = true;


            // Âncoras
            cmbLivro.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            cmbCapitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left;




            CarregarLivros();

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

            this.Resize += MenuForm_Resize;
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
                    if (bubble.Controls[0] is Label label)
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
            float baseFontSize = 16f;
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

        // Cria balão de mensagem
        private Panel CreateMessageBubble(string message, bool isUser)
        {
            var panel = new Panel
            {
                AutoSize = true,
                Padding = new Padding(10),
                Margin = new Padding(5),
                BackColor = isUser ? Color.FromArgb(33, 150, 243) : Color.FromArgb(97, 97, 97),
            };

            var label = new Label
            {
                Text = message,
                AutoSize = true,
                Font = new Font("Segoe UI", 13),
                ForeColor = Color.White
            };

            panel.Controls.Add(label);

            // Definir MaximumSize baseado no flowLayoutPanel atual
            int maxWidth = flowLayoutPanelConversa.ClientSize.Width - 30;
            panel.MaximumSize = new Size(maxWidth, 0);
            label.MaximumSize = new Size(maxWidth - 20, 0);

            // Atualiza a região arredondada sempre que o tamanho mudar
            panel.SizeChanged += (s, e) =>
            {
                var region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 20, 20));
                panel.Region = region;
            };

            // Define a região pela primeira vez
            var initialRegion = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 20, 20));
            panel.Region = initialRegion;

            panel.Anchor = isUser ? AnchorStyles.Right : AnchorStyles.Left;

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
        }

        private async Task EnviarParaOllama(string pergunta)
        {
            try
            {
                var url = "http://localhost:11434/api/generate";

                var requestData = new
                {
                    model = "mistral:latest",
                    prompt = pergunta,
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

        // -------------------- BASE DE DADOS --------------------
        private List<VersiculoSublinhado> ObterGrifosUtilizador(int userId, string livro, int capitulo)
        {
            using (var context = new Entities())
            {
                return context.VersiculoSublinhado
                    .Where(v => v.UserId == userId && v.Livro == livro && v.Capitulo == capitulo)
                    .ToList();
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
            var grifos = ObterGrifosUtilizador(Sessao.UserId, livro, capitulo);

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
                }));
                menu.Items.Add(new ToolStripMenuItem("Explicar", Image.FromFile("icons/ai.png"), async (s, ev) =>
                {
                    int versNumero = Convert.ToInt32(lbl.Tag);
                    string livro = cmbLivro.SelectedItem.ToString();
                    int capitulo = int.Parse(cmbCapitulo.SelectedItem.ToString());

                    // Muda para a aba do chatbot
                    TabControlPrincipal.SelectedTab = tabChatbot;

                    // Cria o prompt
                    string prompt = $"explique o contexto desse {livro}, {capitulo} {versNumero}";

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


    }
}
