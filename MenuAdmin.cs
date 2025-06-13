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

        public PlanoLeitura PlanoCriado { get; private set; }

        private string imagemBase64;
        public MenuAdmin()
        {
            InitializeComponent();

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
            formDias.ShowDialog();

            // Fecha o MenuAdmin depois que o formDias fechar
            this.Close();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
    }
}
