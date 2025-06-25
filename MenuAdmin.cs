using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeLightBible
{
    public partial class MenuAdmin : MaterialForm
    {
        public MenuAdmin()
        {
            InitializeComponent();

            // Ajustes visuais finais
            this.Resize += MenuAdmin_Resize;
            AtualizarLarguraDosCards(flowLayoutPanelPlanos);
            AjustarFonteCards();

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

            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;

        }
        private void MenuAdmin_Resize(object sender, EventArgs e)
        {
            AtualizarLarguraDosCards(flowLayoutPanelPlanos);
            AjustarFonteCards();
        }
        private void MenuAdmin_Load(object sender, EventArgs e)
        {
            CarregarPlanoLeituraTodos();
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

            foreach (Control ctrl in flowLayoutPanelPlanos.Controls)
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

        private void CarregarPlanoLeituraTodos()
        {
            using (var context = new Entities())
            {
                var planos = context.PlanoLeitura.ToList();
                CriarCardsPlanosADM(planos, flowLayoutPanelPlanos);
            }
        }

        private void CriarCardsPlanosADM(List<PlanoLeitura> planos, FlowLayoutPanel flowPanelPlanos)
        {
            flowPanelPlanos.Controls.Clear();
            flowPanelPlanos.Padding = new Padding(10, 50, 10, 20);
            

            foreach (var plano in planos)
            {

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

                card.Controls.Add(btnEditar);
                card.Controls.Add(btnExcluir);

                flowPanelPlanos.Controls.Add(card);
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn?.Parent is MaterialCard card && card.Tag is PlanoLeitura planoSelecionado)
            {
                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir este plano?",
                                                    "Confirmação", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    using (var context = new Entities())
                    {
                        try
                        {
                            // Primeiro, carrega o plano completo com suas dependências se quiser remover tudo
                            var plano = context.PlanoLeitura.Find(planoSelecionado.Id);

                            // Remove dias modelo
                            var diasModelo = context.PlanoLeituraModeloDia.Where(d => d.PlanoLeituraId == plano.Id);
                            context.PlanoLeituraModeloDia.RemoveRange(diasModelo);

                            // Remove registros de utilização
                            var utilizadores = context.PlanoLeituraUtilizador.Where(p => p.PlanoLeituraId == plano.Id).ToList();

                            foreach (var util in utilizadores)
                            {
                                var dias = context.PlanoLeituraDia.Where(d => d.PlanoUtilizadorId == util.Id);
                                context.PlanoLeituraDia.RemoveRange(dias);
                            }

                            context.PlanoLeituraUtilizador.RemoveRange(utilizadores);

                            // Por fim, remove o plano
                            context.PlanoLeitura.Remove(plano);
                            context.SaveChanges();

                            MessageBox.Show("Plano excluído com sucesso!");
                            CarregarPlanoLeituraTodos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao excluir: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            // Obtém o botão que foi clicado
            Button btn = sender as Button;

            MenuAdmin menu = this.FindForm() as MenuAdmin;
            menu?.Hide();

            // Sobe até o card (pai do botão) e pega o objeto PlanoLeitura que está no Tag
            if (btn?.Parent is MaterialCard card && card.Tag is PlanoLeitura planoSelecionado)
            {
                int planoId = planoSelecionado.Id;

                using (FormPlanoDiasAdmin formDias = new FormPlanoDiasAdmin(planoId))
                {
                    formDias.ShowDialog();
                }
            }
        }

        private void btnCriarPlano_Click(object sender, EventArgs e)
        {


            // Fecha o MenuAdmin (este form)
            this.Hide();

            // Abre o FormPlanoDiasAdmin
            var formPlano = new CriarPlanoLeitura();
            formPlano.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }
    }
}
