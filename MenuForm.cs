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

namespace BeLightBible
{
    public partial class MenuForm : MaterialForm
    {
        private Livro livros = new Livro();
       

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
        }

        private void CarregarLivros()
        {
            var livrosDictionary = livros.ObterLivros();
            foreach (var livro in livrosDictionary)
            {
                cmbLivro.Items.Add(livro.Key); // Adiciona o nome do livro
            }
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
    }
}
