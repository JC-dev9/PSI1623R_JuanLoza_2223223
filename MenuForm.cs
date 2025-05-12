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
using Newtonsoft.Json;

namespace BeLightBible
{
    public partial class MenuForm : MaterialForm
    {
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

            string url = $"https://bible-api.com/{livro}+{capitulo}?translation=almeida";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        dynamic data = JsonConvert.DeserializeObject(json);

                        flowLayoutPanelVersiculos.Controls.Clear(); // Limpa os antigos

                        foreach (var versiculo in data.verses)
                        {
                            MaterialLabel lbl = new MaterialLabel();
                            lbl.Text = $"{versiculo.verse}: {versiculo.text}";
                            lbl.Tag = (int)versiculo.verse;
                            lbl.Cursor = Cursors.Hand;
                            lbl.MouseClick += new MouseEventHandler(VersiculoClicado);
                            lbl.AutoSize = true;
                            lbl.Margin = new Padding(5);
                            float tamanhoFonte = this.Width / 70f; // Ajuste esse valor como quiser
                            lbl.Font = new Font("Roboto", tamanhoFonte);

                            var card = new Panel()
                            {
                                Padding = new Padding(10),
                                Margin = new Padding(5),
                                AutoSize = true,
                            };

                            lbl.ForeColor = Color.White;
                            lbl.BackColor = Color.Transparent;

                            card.Controls.Add(lbl);
                            flowLayoutPanelVersiculos.Controls.Add(card);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro ao buscar versículos da API.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }
        }

        private async Task SetupBibleTab()
        {
            // Simula um atraso para mostrar o carregamento
            // await Task.Delay(2000);

            // Aqui você pode adicionar o código para carregar a Bíblia
            // Por exemplo, carregar os livros, capítulos e versículos da Bíblia
            // Isso pode incluir chamadas a APIs ou consultas a bancos de dados
            // lblLoading.Visible = false; // Esconde o rótulo de carregamento
        }

        private void GrifarVersiculo(MaterialLabel lbl)
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
            MaterialLabel lbl = sender as MaterialLabel;
            int numero = (int)lbl.Tag;

            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add("Grifar", (s, ev) => GrifarVersiculo(lbl));
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
            var livros = new List<string> { "Gênesis", "Êxodo", "Levítico", "Números", "Deuteronômio" }; // Pode expandir

            cmbLivro.Items.AddRange(livros.ToArray());
            cmbLivro.SelectedIndex = 0;

            for (int i = 1; i <= 50; i++) // Ex: Gênesis tem até 50
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
