using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeLightBible
{
    public partial class CriarPlanoLeitura : MaterialForm
    {
        public PlanoLeitura PlanoCriado { get; private set; }

        // Variável para armazenar a imagem em Base64
        private string imagemBase64;
        public CriarPlanoLeitura()
        {
            InitializeComponent();

            // Serve para impedir redimensionamento
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

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

            txtDias.KeyPress += txtDias_KeyPress;
        }

        private void btnSelecionarImagem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imagens|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    byte[] imgBytes = File.ReadAllBytes(ofd.FileName);
                    imagemBase64 = Convert.ToBase64String(imgBytes);
                    pictureBoxPreview.Image = Image.FromStream(new MemoryStream(imgBytes));
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtDescricao.Text) ||
                string.IsNullOrWhiteSpace(txtDias.Text) ||
                string.IsNullOrEmpty(imagemBase64))
            {
                MessageBox.Show("Preencha todos os campos e selecione uma imagem.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDias.Text, out int dias))
            {
                MessageBox.Show("Digite um número válido para os dias.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dias < 1 || dias > 365)
            {
                MessageBox.Show("O número de dias deve estar entre 1 e 365.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PlanoCriado = new PlanoLeitura
            {
                Nome = txtNome.Text,
                Descricao = txtDescricao.Text,
                DiasDuracao = dias,
                ImagemBase64 = imagemBase64
            };

            using (var db = new Entities())
            {
                db.PlanoLeitura.Add(PlanoCriado);
                db.SaveChanges();
            }

            int planoId = PlanoCriado.Id;

            // Fecha o MenuAdmin (este form)
            this.Hide();

            // Abre o FormPlanoDiasAdmin
            var formDias = new FormPlanoDiasAdmin(planoId);
            formDias.Show();

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "Tem certeza que deseja não criar o plano?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Fecha o MenuAdmin (este form)
                this.Hide();

                // Abre o FormPlanoDiasAdmin
                var formDias = new MenuAdmin();
                formDias.Show();
            }
        }


        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Impede letras, símbolos, etc.
            }
        }
    }
}
