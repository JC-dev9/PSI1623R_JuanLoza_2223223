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
using System.Speech.Synthesis;

namespace BeLightBible
{
    public partial class MenuForm : MaterialForm
    {
        private PictureBox picLoading;
        private Livro livros = new Livro();
        private Estilo estilo = new Estilo();
        private Label lblTituloCapitulo;
        private readonly ApiBibleService bibleService = new ApiBibleService();

        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private bool isPlaying = false;

        public MenuForm()
        {
            InitializeComponent();

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

            CarregarLivros();

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

            estilo.EstilizarPictureBoxComoBotao(picBtnProximoCapitulo, true, cmbLivro, cmbCapitulo, BibleTab);
            estilo.EstilizarPictureBoxComoBotao(picBtnAnteriorCapitulo, false, cmbLivro, cmbCapitulo, BibleTab);
            estilo.EstilizarPictureBoxAudio(picAudio);

            estilo.ArredondarControle(picBtnProximoCapitulo, 10);
            estilo.ArredondarControle(picBtnAnteriorCapitulo, 10);
            estilo.ArredondarControle(picAudio, 10);
        }

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

            picLoading.Visible = false;
        }

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

        private void VersiculoClicado(object sender, MouseEventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.Font = new Font(lbl.Font, lbl.Font.Style | FontStyle.Underline);
                Versiculo versiculo = new Versiculo(lbl);

                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add(new ToolStripMenuItem("Grifar", Image.FromFile("icons/palette.png"), (s, ev) => versiculo.Grifar()));
                menu.Items.Add(new ToolStripMenuItem("Copiar", Image.FromFile("icons/copy.png"), (s, ev) => versiculo.Copiar()));

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
