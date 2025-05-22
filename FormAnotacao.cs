using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BeLightBible
{
    public partial class FormAnotacao : MaterialForm
    {
        private MaterialMultiLineTextBox2 txtAnotacao;
        private MaterialButton btnSalvar;
        private MaterialButton btnCancelar;

        public string TextoAnotacao { get; private set; }

        public FormAnotacao(string textoAtual)
        {
            InitializeComponent();
            InitializeMaterialSkin();
            CriarComponentes(textoAtual);
        }

        private void InitializeMaterialSkin()
        {
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

        private void CriarComponentes(string textoAtual)
        {
            this.Text = "Anotação";
            this.Size = new System.Drawing.Size(500, 360);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            txtAnotacao = new MaterialMultiLineTextBox2
            {
                Hint = "Escreve aqui tua anotação...",
                Size = new System.Drawing.Size(440, 180),
                Location = new System.Drawing.Point(30, 80),
                Text = textoAtual,
                BackColor = System.Drawing.Color.FromArgb(55, 55, 55),
                ForeColor = System.Drawing.Color.White
            };

            btnSalvar = new MaterialButton
            {
                Text = "Salvar",
                Location = new System.Drawing.Point(260, 270),
                AutoSize = false,
                Size = new System.Drawing.Size(100, 36)
            };
            btnSalvar.Click += BtnSalvar_Click;

            btnCancelar = new MaterialButton
            {
                Text = "Cancelar",
                Location = new System.Drawing.Point(370, 270),
                AutoSize = false,
                Size = new System.Drawing.Size(100, 36)
            };
            btnCancelar.Click += BtnCancelar_Click;

            Controls.Add(txtAnotacao);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);

            this.ActiveControl = btnCancelar;
            this.Resize += (s, e) => this.Size = new System.Drawing.Size(500, 360);
        }

        // Impede que a janela seja movida pelo utilizador
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 0xA1;
            const int HTCAPTION = 0x2;

            // Se tentar clicar na barra de título (HTCAPTION), cancela
            if (m.Msg == WM_NCLBUTTONDOWN && m.WParam.ToInt32() == HTCAPTION)
                return;

            base.WndProc(ref m);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "Tem certeza que deseja salvar a anotação?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (resultado == DialogResult.Yes)
            {
                TextoAnotacao = txtAnotacao.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
