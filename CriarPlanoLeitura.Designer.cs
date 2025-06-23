namespace BeLightBible
{
    partial class CriarPlanoLeitura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.tabCriarPlano = new System.Windows.Forms.TabPage();
            this.lblNome = new MaterialSkin.Controls.MaterialLabel();
            this.lblDescricao = new MaterialSkin.Controls.MaterialLabel();
            this.lblDuracao = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.txtNome = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDescricao = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDias = new MaterialSkin.Controls.MaterialTextBox();
            this.btnSelecionarImagem = new MaterialSkin.Controls.MaterialButton();
            this.btnSalvar = new MaterialSkin.Controls.MaterialButton();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.btnCancelar = new MaterialSkin.Controls.MaterialButton();
            this.tabCriarPlano.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.materialTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCriarPlano
            // 
            this.tabCriarPlano.Controls.Add(this.btnCancelar);
            this.tabCriarPlano.Controls.Add(this.btnSalvar);
            this.tabCriarPlano.Controls.Add(this.btnSelecionarImagem);
            this.tabCriarPlano.Controls.Add(this.txtDias);
            this.tabCriarPlano.Controls.Add(this.txtDescricao);
            this.tabCriarPlano.Controls.Add(this.txtNome);
            this.tabCriarPlano.Controls.Add(this.pictureBoxPreview);
            this.tabCriarPlano.Controls.Add(this.lblDuracao);
            this.tabCriarPlano.Controls.Add(this.lblDescricao);
            this.tabCriarPlano.Controls.Add(this.lblNome);
            this.tabCriarPlano.ImageKey = "auto_stories_24dp_E3E3E3_FILL0_wght400_GRAD0_opsz24(1).png";
            this.tabCriarPlano.Location = new System.Drawing.Point(4, 25);
            this.tabCriarPlano.Name = "tabCriarPlano";
            this.tabCriarPlano.Padding = new System.Windows.Forms.Padding(3);
            this.tabCriarPlano.Size = new System.Drawing.Size(804, 388);
            this.tabCriarPlano.TabIndex = 0;
            this.tabCriarPlano.Text = "Plano de Leitura";
            this.tabCriarPlano.UseVisualStyleBackColor = true;
            // 
            // lblNome
            // 
            this.lblNome.Depth = 0;
            this.lblNome.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNome.Location = new System.Drawing.Point(36, 14);
            this.lblNome.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(300, 20);
            this.lblNome.TabIndex = 3;
            this.lblNome.Text = "Nome do Plano:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.Depth = 0;
            this.lblDescricao.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDescricao.Location = new System.Drawing.Point(36, 242);
            this.lblDescricao.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(300, 20);
            this.lblDescricao.TabIndex = 5;
            this.lblDescricao.Text = "Descrição do Plano:";
            // 
            // lblDuracao
            // 
            this.lblDuracao.Depth = 0;
            this.lblDuracao.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDuracao.Location = new System.Drawing.Point(36, 130);
            this.lblDuracao.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDuracao.Name = "lblDuracao";
            this.lblDuracao.Size = new System.Drawing.Size(300, 20);
            this.lblDuracao.TabIndex = 7;
            this.lblDuracao.Text = "Duração do Plano:";
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview.Location = new System.Drawing.Point(512, 29);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(135, 117);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 10;
            this.pictureBoxPreview.TabStop = false;
            // 
            // txtNome
            // 
            this.txtNome.AnimateReadOnly = false;
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNome.CausesValidation = false;
            this.txtNome.Depth = 0;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtNome.Hint = "Insira o nome";
            this.txtNome.LeadingIcon = null;
            this.txtNome.Location = new System.Drawing.Point(36, 46);
            this.txtNome.MaxLength = 50;
            this.txtNome.MouseState = MaterialSkin.MouseState.OUT;
            this.txtNome.Multiline = false;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(300, 50);
            this.txtNome.TabIndex = 4;
            this.txtNome.Text = "";
            this.txtNome.TrailingIcon = null;
            // 
            // txtDescricao
            // 
            this.txtDescricao.AnimateReadOnly = false;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescricao.CausesValidation = false;
            this.txtDescricao.Depth = 0;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDescricao.Hint = "Descrição";
            this.txtDescricao.LeadingIcon = null;
            this.txtDescricao.Location = new System.Drawing.Point(36, 274);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDescricao.Multiline = false;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(300, 50);
            this.txtDescricao.TabIndex = 6;
            this.txtDescricao.Text = "";
            this.txtDescricao.TrailingIcon = null;
            // 
            // txtDias
            // 
            this.txtDias.AnimateReadOnly = false;
            this.txtDias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDias.CausesValidation = false;
            this.txtDias.Depth = 0;
            this.txtDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDias.Hint = "Número de dias (ex: 7)";
            this.txtDias.LeadingIcon = null;
            this.txtDias.Location = new System.Drawing.Point(36, 162);
            this.txtDias.MaxLength = 50;
            this.txtDias.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDias.Multiline = false;
            this.txtDias.Name = "txtDias";
            this.txtDias.Size = new System.Drawing.Size(300, 50);
            this.txtDias.TabIndex = 8;
            this.txtDias.Text = "";
            this.txtDias.TrailingIcon = null;
            // 
            // btnSelecionarImagem
            // 
            this.btnSelecionarImagem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSelecionarImagem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSelecionarImagem.Depth = 0;
            this.btnSelecionarImagem.HighEmphasis = true;
            this.btnSelecionarImagem.Icon = null;
            this.btnSelecionarImagem.Location = new System.Drawing.Point(496, 155);
            this.btnSelecionarImagem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSelecionarImagem.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSelecionarImagem.Name = "btnSelecionarImagem";
            this.btnSelecionarImagem.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSelecionarImagem.Size = new System.Drawing.Size(170, 36);
            this.btnSelecionarImagem.TabIndex = 9;
            this.btnSelecionarImagem.Text = "Selecionar Imagem";
            this.btnSelecionarImagem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSelecionarImagem.UseAccentColor = false;
            this.btnSelecionarImagem.UseVisualStyleBackColor = true;
            this.btnSelecionarImagem.Click += new System.EventHandler(this.btnSelecionarImagem_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSalvar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSalvar.Depth = 0;
            this.btnSalvar.HighEmphasis = true;
            this.btnSalvar.Icon = null;
            this.btnSalvar.Location = new System.Drawing.Point(561, 352);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSalvar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSalvar.Size = new System.Drawing.Size(76, 36);
            this.btnSalvar.TabIndex = 11;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSalvar.UseAccentColor = false;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabCriarPlano);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 77);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(812, 417);
            this.materialTabControl1.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancelar.Depth = 0;
            this.btnCancelar.HighEmphasis = true;
            this.btnCancelar.Icon = null;
            this.btnCancelar.Location = new System.Drawing.Point(679, 352);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancelar.Size = new System.Drawing.Size(96, 36);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancelar.UseAccentColor = false;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CriarPlanoLeitura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 497);
            this.Controls.Add(this.materialTabControl1);
            this.Name = "CriarPlanoLeitura";
            this.Text = "CriarPlanoLeitura";
            this.tabCriarPlano.ResumeLayout(false);
            this.tabCriarPlano.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.materialTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabCriarPlano;
        private MaterialSkin.Controls.MaterialButton btnSalvar;
        private MaterialSkin.Controls.MaterialButton btnSelecionarImagem;
        private MaterialSkin.Controls.MaterialTextBox txtDias;
        private MaterialSkin.Controls.MaterialTextBox txtDescricao;
        private MaterialSkin.Controls.MaterialTextBox txtNome;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private MaterialSkin.Controls.MaterialLabel lblDuracao;
        private MaterialSkin.Controls.MaterialLabel lblDescricao;
        private MaterialSkin.Controls.MaterialLabel lblNome;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private MaterialSkin.Controls.MaterialButton btnCancelar;
    }
}