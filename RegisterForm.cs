using MaterialSkin.Controls;
using MaterialSkin;
using System.Windows.Forms;
using System.Data.SqlClient;
using System;

namespace BeLightBible
{
    public partial class RegisterForm : MaterialForm
    {


        public RegisterForm()
        {
            InitializeComponent();

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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Utilizador user = new Utilizador();

            string username = txtNewUsername.Text.Trim();
            string email = txtNewEmail.Text.Trim();
            string password = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (user.ExisteUtilizador(txtNewUsername.Text.Trim()))
            {
                MessageBox.Show("Nome de utilizador já em uso.", "Warning" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (user.Registrar(username, email, password))
            {
                MessageBox.Show("Registro bem-sucedido!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var loginForm = new LoginForm();
                loginForm.Show();
                this.Hide(); // Esconde o formulário de registro
            }
            else
            {
                MessageBox.Show("Erro ao registrar o utilizador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void lblBackToLogin_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Hide(); // Esconde o formulário de registro
        }
    }
}
