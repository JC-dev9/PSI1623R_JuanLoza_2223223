using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;

namespace BeLightBible
{
    public partial class LoginForm : MaterialForm
    {
        public LoginForm()
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Utilizador user = new Utilizador();

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (user.Autenticar(username, password))
            {
                // Salva Informações na sessão
                Sessao.Username = username;
                Sessao.UserId = user.ObterUserId(username);

                // Abre a tela principal 
                var mainForm = new MenuForm();
                mainForm.Show();
                this.Hide(); // Esconde o formulário de login

            }
            else
            {
                MessageBox.Show("Nome de utilizador ou senha incorretos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblRegisterLink_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide(); // Esconde o formulário de login
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.UseAccent = false;
            txtPassword.UseAccent = false;
        }

    }
}
