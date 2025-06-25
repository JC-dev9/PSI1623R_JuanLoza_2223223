using System;
using System.Drawing;
using System.Windows.Forms;

namespace BeLightBible
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialLabel lblNewUsername;
        private MaterialSkin.Controls.MaterialLabel lblNewPassword;
        private MaterialSkin.Controls.MaterialLabel lblNewEmail;
        private MaterialSkin.Controls.MaterialTextBox txtNewUsername;
        private MaterialSkin.Controls.MaterialTextBox txtNewPassword;
        private MaterialSkin.Controls.MaterialTextBox txtNewEmail;
        private MaterialSkin.Controls.MaterialButton btnRegister;
        private MaterialSkin.Controls.MaterialLabel lblBackToLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.lblNewUsername = new MaterialSkin.Controls.MaterialLabel();
            this.lblNewPassword = new MaterialSkin.Controls.MaterialLabel();
            this.lblNewEmail = new MaterialSkin.Controls.MaterialLabel();
            this.txtNewUsername = new MaterialSkin.Controls.MaterialTextBox();
            this.txtNewPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.txtNewEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.btnRegister = new MaterialSkin.Controls.MaterialButton();
            this.lblBackToLogin = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // lblNewUsername
            // 
            this.lblNewUsername.Depth = 0;
            this.lblNewUsername.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNewUsername.Location = new System.Drawing.Point(250, 120);
            this.lblNewUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNewUsername.Name = "lblNewUsername";
            this.lblNewUsername.Size = new System.Drawing.Size(300, 20);
            this.lblNewUsername.TabIndex = 1;
            this.lblNewUsername.Text = "Novo Utilizador:";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.Depth = 0;
            this.lblNewPassword.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNewPassword.Location = new System.Drawing.Point(250, 211);
            this.lblNewPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(300, 20);
            this.lblNewPassword.TabIndex = 3;
            this.lblNewPassword.Text = "Nova Palavra-Passe:";
            // 
            // lblNewEmail
            // 
            this.lblNewEmail.Depth = 0;
            this.lblNewEmail.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNewEmail.Location = new System.Drawing.Point(250, 304);
            this.lblNewEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNewEmail.Name = "lblNewEmail";
            this.lblNewEmail.Size = new System.Drawing.Size(300, 20);
            this.lblNewEmail.TabIndex = 5;
            this.lblNewEmail.Text = "Email:";
            // 
            // txtNewUsername
            // 
            this.txtNewUsername.AnimateReadOnly = false;
            this.txtNewUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewUsername.Depth = 0;
            this.txtNewUsername.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtNewUsername.Hint = "Digite o nome de utilizador";
            this.txtNewUsername.LeadingIcon = null;
            this.txtNewUsername.Location = new System.Drawing.Point(250, 145);
            this.txtNewUsername.MaxLength = 50;
            this.txtNewUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.txtNewUsername.Multiline = false;
            this.txtNewUsername.Name = "txtNewUsername";
            this.txtNewUsername.Size = new System.Drawing.Size(300, 50);
            this.txtNewUsername.TabIndex = 2;
            this.txtNewUsername.Text = "";
            this.txtNewUsername.TrailingIcon = null;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.AnimateReadOnly = false;
            this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewPassword.Depth = 0;
            this.txtNewPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtNewPassword.Hint = "Digite a palavra-passe";
            this.txtNewPassword.LeadingIcon = null;
            this.txtNewPassword.Location = new System.Drawing.Point(250, 236);
            this.txtNewPassword.MaxLength = 50;
            this.txtNewPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtNewPassword.Multiline = false;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Password = true;
            this.txtNewPassword.Size = new System.Drawing.Size(300, 50);
            this.txtNewPassword.TabIndex = 4;
            this.txtNewPassword.Text = "";
            this.txtNewPassword.TrailingIcon = null;
            // 
            // txtNewEmail
            // 
            this.txtNewEmail.AnimateReadOnly = false;
            this.txtNewEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewEmail.Depth = 0;
            this.txtNewEmail.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtNewEmail.Hint = "Digite o email";
            this.txtNewEmail.LeadingIcon = null;
            this.txtNewEmail.Location = new System.Drawing.Point(250, 329);
            this.txtNewEmail.MaxLength = 50;
            this.txtNewEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.txtNewEmail.Multiline = false;
            this.txtNewEmail.Name = "txtNewEmail";
            this.txtNewEmail.Size = new System.Drawing.Size(300, 50);
            this.txtNewEmail.TabIndex = 6;
            this.txtNewEmail.Text = "";
            this.txtNewEmail.TrailingIcon = null;
            // 
            // btnRegister
            // 
            this.btnRegister.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRegister.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRegister.Depth = 0;
            this.btnRegister.HighEmphasis = true;
            this.btnRegister.Icon = null;
            this.btnRegister.Location = new System.Drawing.Point(353, 388);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRegister.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRegister.Size = new System.Drawing.Size(90, 36);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Registar";
            this.btnRegister.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRegister.UseAccentColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblBackToLogin
            // 
            this.lblBackToLogin.AutoSize = true;
            this.lblBackToLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBackToLogin.Depth = 0;
            this.lblBackToLogin.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBackToLogin.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblBackToLogin.Location = new System.Drawing.Point(290, 439);
            this.lblBackToLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBackToLogin.Name = "lblBackToLogin";
            this.lblBackToLogin.Size = new System.Drawing.Size(214, 19);
            this.lblBackToLogin.TabIndex = 8;
            this.lblBackToLogin.Text = "Já tem conta? Voltar ao Login";
            this.lblBackToLogin.Click += new System.EventHandler(this.lblBackToLogin_Click);
            // 
            // RegisterForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.lblNewUsername);
            this.Controls.Add(this.txtNewUsername);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblNewEmail);
            this.Controls.Add(this.txtNewEmail);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblBackToLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BeLight Bible";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
