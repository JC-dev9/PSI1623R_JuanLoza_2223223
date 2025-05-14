using MaterialSkin.Controls;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using BeLightBible.Services;
using Newtonsoft.Json;

namespace BeLightBible
{
    public partial class MenuForm : MaterialForm
    {
        private readonly ApiBibleService bibleService = new ApiBibleService();
        private readonly MaterialSkinManager materialSkinManager;
        public MenuForm()
        {
            InitializeComponent();
         
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(
            Primary.BlueGrey500,
            Primary.BlueGrey700,
            Primary.BlueGrey100,
            Accent.DeepOrange200,      // Um leve toque de luz (revela/ilumina)
            TextShade.WHITE
);
        }

        private async Task BibleTab(string livro, int capitulo)
        {
            var data = await bibleService.BuscarVersiculo(livro, capitulo);

            if (data == null)
            {
                MessageBox.Show("Erro ao buscar versículos da API.");
                return;
            }

            flowLayoutPanelVersiculos.Controls.Clear();

            foreach (var versiculo in data.verses)
                        {
                            Label lbl = new Label();
                            lbl.Text = $"{versiculo.verse}: {versiculo.text}";
                            lbl.Tag = (int)versiculo.verse;
                            lbl.Cursor = Cursors.Hand;
                            lbl.MouseClick += new MouseEventHandler(VersiculoClicado);


                            float tamanhoFonte = this.Width / 70f; // Ajuste esse valor como quiser

                            lbl.AutoSize = true;
                            lbl.Height = TextRenderer.MeasureText(lbl.Text, lbl.Font, new Size(lbl.Width, int.MaxValue), TextFormatFlags.WordBreak).Height + 20;

                            lbl.MaximumSize = new Size(flowLayoutPanelVersiculos.ClientSize.Width - 20, 0);
                            lbl.Width = flowLayoutPanelVersiculos.ClientSize.Width - 20;
                            lbl.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                            lbl.Margin = new Padding(1);
                            lbl.Padding = new Padding(1);

                            var card = new Panel()
                            {
                                Padding = new Padding(1),
                                Margin = new Padding(1),
                                AutoSize = true,
                            };

                            lbl.ForeColor = Color.White;
                            lbl.BackColor = Color.Transparent;

                            card.Controls.Add(lbl);
                            flowLayoutPanelVersiculos.Controls.Add(card);
                        }
            

            
        }

        private void GrifarVersiculo(Label lbl)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lbl.BackColor = colorDialog.Color;

                // Aqui você pode salvar no banco:
                // SalvarGrifoNaBase(lbl.Text, lbl.BackColor, usuarioId);
            }
        }
        private void VersiculoClicado(object sender, MouseEventArgs e)
        {

                Label lbl = sender as Label;
                int numero = (int)lbl.Tag;

                // Sublinha o texto
                lbl.Font = new Font(lbl.Font, lbl.Font.Style | FontStyle.Underline);

                // Cria um ContextMenuStrip (mais moderno que ContextMenu)
                ContextMenuStrip menu = new ContextMenuStrip();

                // Adiciona a opção "Grifar"
                menu.Items.Add("Grifar", null, (s, ev) => GrifarVersiculo(lbl));

                // Quando o menu for fechado, remove o sublinhado
                menu.Closed += (s, ev) =>
                {
                    lbl.Font = new Font(lbl.Font, lbl.Font.Style & ~FontStyle.Underline);
                };

                // Mostra o menu na posição do clique
                menu.Show(lbl, new Point(e.X, e.Y));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Hide(); // Esconde o formulário de menu
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            // Obter todos os livros e adicionar no combo box

            var livros = Versiculo.GetTodosOsLivros();
            cmbLivro.Items.AddRange(livros.ToArray());
            cmbLivro.SelectedIndex = 0;

            // Limpar capítulos ao mudar de livro
            cmbCapitulo.Items.Clear();

            string livroSelecionado = cmbLivro.SelectedItem.ToString();
            int numeroCapitulos = Versiculo.GetNumeroDeCapitulos(livroSelecionado);

            for (int i = 1; i <= numeroCapitulos; i++)
                cmbCapitulo.Items.Add(i.ToString());

            cmbCapitulo.SelectedIndex = 0;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string livro = cmbLivro.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(livro))
            {
                MessageBox.Show("Por favor, selecione um livro.");
                return;
            }

            if (!int.TryParse(cmbCapitulo.SelectedItem?.ToString(), out int capitulo))
            {
                MessageBox.Show("Selecione um capítulo válido.");
                return;
            }

            await BibleTab(livro, capitulo);
        }
    }
}
