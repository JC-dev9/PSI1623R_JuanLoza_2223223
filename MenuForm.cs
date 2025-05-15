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

namespace BeLightBible
{
    public partial class MenuForm : MaterialForm
    {
        private Livro livros = new Livro();
        private Label lblTituloCapitulo;
        private readonly ApiBibleService bibleService = new ApiBibleService();

        public MenuForm()
        {
            InitializeComponent();
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

            // Estilizar o PictureBox como botão
            EstilizarPictureBoxComoBotao(picBtnProximoCapitulo, proximo: true);
            EstilizarPictureBoxComoBotao(picBtnAnteriorCapitulo, proximo: false);

            // Arrendondar bordas   
            ArredondarControle(picBtnProximoCapitulo, 10);
            ArredondarControle(picBtnAnteriorCapitulo, 10);
        }

        private void CarregarLivros()
        {
            var livrosDictionary = livros.ObterLivros();
            foreach (var livro in livrosDictionary)
            {
                cmbLivro.Items.Add(livro.Key); // Adiciona o nome do livro
            }
        }

        private void EstilizarPictureBoxComoBotao(PictureBox pic, bool proximo)
        {
            pic.BackColor = Color.FromArgb(33, 150, 243); // Azul Material
            pic.SizeMode = PictureBoxSizeMode.CenterImage;
            pic.Cursor = Cursors.Hand;
            pic.Padding = new Padding(8);

            pic.BackColor = Color.FromArgb(255, 138, 101); // DeepOrange200
            pic.MouseEnter += (s, e) => pic.BackColor = Color.FromArgb(255, 112, 67);  // DeepOrange300
            pic.MouseDown += (s, e) => pic.BackColor = Color.FromArgb(230, 74, 25);    // DeepOrange700
            pic.MouseUp += (s, e) => pic.BackColor = Color.FromArgb(255, 112, 67);


            pic.Click += async (s, e) =>
            {
                if (proximo && cmbCapitulo.SelectedIndex < cmbCapitulo.Items.Count - 1)
                {
                    cmbCapitulo.SelectedIndex += 1;
                    await BibleTab(cmbLivro.SelectedItem.ToString(), cmbCapitulo.SelectedIndex + 1);
                }
                else if (!proximo && cmbCapitulo.SelectedIndex > 0)
                {
                    cmbCapitulo.SelectedIndex -= 1;
                    await BibleTab(cmbLivro.SelectedItem.ToString(), cmbCapitulo.SelectedIndex + 1);
                }
                else if (!proximo && cmbCapitulo.SelectedIndex > 0)
                {
                    cmbCapitulo.SelectedIndex -= 1;
                    await BibleTab(cmbLivro.SelectedItem.ToString(), cmbCapitulo.SelectedIndex + 1);
                }
                else if (cmbCapitulo.SelectedIndex == cmbCapitulo.Items.Count - 1 && proximo)
                {
                    MessageBox.Show("Você já está no último capítulo.");
                }
                else if (cmbCapitulo.Items.Count == 0)
                {
                    MessageBox.Show("Selecione um livro primeiro.");
                }
                else if (cmbCapitulo.SelectedIndex == 0 && !proximo)
                {
                    MessageBox.Show("Você já está no primeiro capítulo.");
                }
            };
        }

        private void ArredondarControle(Control controle, int raio)
        {
            var path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, raio, raio), 180, 90);
            path.AddArc(new Rectangle(controle.Width - raio, 0, raio, raio), 270, 90);
            path.AddArc(new Rectangle(controle.Width - raio, controle.Height - raio, raio, raio), 0, 90);
            path.AddArc(new Rectangle(0, controle.Height - raio, raio, raio), 90, 90);
            path.CloseFigure();

            controle.Region = new Region(path);
        }


        private async Task BibleTab(string livro, int capitulo)
        {
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
        }

        private void cmbLivro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomeLivro = cmbLivro.SelectedItem as string;

            if (string.IsNullOrEmpty(nomeLivro))
                return;

            cmbCapitulo.Items.Clear();

            // Obtém o número de capítulos para o livro selecionado
            int totalCapitulos = livros.ObterNumeroDeCapitulos(nomeLivro);

            for (int i = 1; i <= totalCapitulos; i++)
            {
                cmbCapitulo.Items.Add(i.ToString());
            }

            // Se houver capítulos, seleciona o primeiro por padrão
            if (cmbCapitulo.Items.Count > 0)
                cmbCapitulo.SelectedIndex = 0;
        }

        private void GrifarVersiculo(Label lbl)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lbl.BackColor = colorDialog.Color;
                // salvar no banco aqui, se necessário
            }
        }

        private void VersiculoClicado(object sender, MouseEventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.Font = new Font(lbl.Font, lbl.Font.Style | FontStyle.Underline);

                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Grifar", null, (s, ev) => GrifarVersiculo(lbl));

                menu.Closed += (s, ev) =>
                {
                    lbl.Font = new Font(lbl.Font, lbl.Font.Style & ~FontStyle.Underline);
                };

                menu.Show(lbl, new Point(e.X, e.Y));
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtém o nome do livro selecionado diretamente
            string livro = cmbLivro.SelectedItem as string;

            if (string.IsNullOrEmpty(livro))
            {
                MessageBox.Show("Selecione um livro.");
                return;
            }

            // Verifica o capítulo selecionado
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

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}
