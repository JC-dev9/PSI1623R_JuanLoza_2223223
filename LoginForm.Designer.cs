using System.Drawing;
using System.Windows.Forms;

namespace BeLightBible
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialLabel lblUsername;
        private MaterialSkin.Controls.MaterialLabel lblPassword;
        private MaterialSkin.Controls.MaterialTextBox txtUsername;
        private MaterialSkin.Controls.MaterialTextBox txtPassword;
        private MaterialSkin.Controls.MaterialButton btnLogin;
        private MaterialSkin.Controls.MaterialLabel lblRegisterLink;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUsername = new MaterialSkin.Controls.MaterialLabel();
            this.lblPassword = new MaterialSkin.Controls.MaterialLabel();
            this.txtUsername = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.btnLogin = new MaterialSkin.Controls.MaterialButton();
            this.lblRegisterLink = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.Depth = 0;
            this.lblUsername.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblUsername.Location = new System.Drawing.Point(254, 161);
            this.lblUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(300, 20);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Utilizador:";
            // 
            // lblPassword
            // 
            this.lblPassword.Depth = 0;
            this.lblPassword.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPassword.Location = new System.Drawing.Point(254, 250);
            this.lblPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(300, 20);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Palavra-Passe:";
            // 
            // txtUsername
            // 
            this.txtUsername.AnimateReadOnly = false;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.CausesValidation = false;
            this.txtUsername.Depth = 0;
            this.txtUsername.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtUsername.Hint = "Digite seu utilizador";
            this.txtUsername.LeadingIcon = null;
            this.txtUsername.Location = new System.Drawing.Point(254, 186);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(300, 50);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.Text = "";
            this.txtUsername.TrailingIcon = null;
            // 
            // txtPassword
            // 
            this.txtPassword.AnimateReadOnly = false;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Depth = 0;
            this.txtPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.Hint = "Digite sua palavra-passe";
            this.txtPassword.LeadingIcon = null;
            this.txtPassword.Location = new System.Drawing.Point(254, 275);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Password = true;
            this.txtPassword.Size = new System.Drawing.Size(300, 50);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Text = "";
            this.txtPassword.TrailingIcon = null;
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogin.Depth = 0;
            this.btnLogin.HighEmphasis = true;
            this.btnLogin.Icon = null;
            this.btnLogin.Location = new System.Drawing.Point(365, 334);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLogin.Size = new System.Drawing.Size(77, 36);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Entrar";
            this.btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogin.UseAccentColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblRegisterLink
            // 
            this.lblRegisterLink.AutoSize = true;
            this.lblRegisterLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRegisterLink.Depth = 0;
            this.lblRegisterLink.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRegisterLink.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblRegisterLink.Location = new System.Drawing.Point(284, 386);
            this.lblRegisterLink.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRegisterLink.Name = "lblRegisterLink";
            this.lblRegisterLink.Size = new System.Drawing.Size(231, 19);
            this.lblRegisterLink.TabIndex = 6;
            this.lblRegisterLink.Text = "Não tem uma conta? Registar-se";
            this.lblRegisterLink.Click += new System.EventHandler(this.lblRegisterLink_Click);
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(818, 497);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblRegisterLink);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BeLight Bible";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}