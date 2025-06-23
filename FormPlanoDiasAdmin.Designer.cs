namespace BeLightBible
{
    partial class FormPlanoDiasAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlanoDiasAdmin));
            this.btnSalvarDia = new MaterialSkin.Controls.MaterialButton();
            this.listDia = new MaterialSkin.Controls.MaterialListBox();
            this.numericUpDownDia = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLivro = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbCapitulo = new MaterialSkin.Controls.MaterialComboBox();
            this.btnVoltarTelaAdmin = new MaterialSkin.Controls.MaterialButton();
            this.picBtnProximoDia = new System.Windows.Forms.PictureBox();
            this.picBtnAnteriorDia = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnProximoDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnAnteriorDia)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvarDia
            // 
            this.btnSalvarDia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSalvarDia.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSalvarDia.Depth = 0;
            this.btnSalvarDia.HighEmphasis = true;
            this.btnSalvarDia.Icon = null;
            this.btnSalvarDia.Location = new System.Drawing.Point(27, 334);
            this.btnSalvarDia.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSalvarDia.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSalvarDia.Name = "btnSalvarDia";
            this.btnSalvarDia.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSalvarDia.Size = new System.Drawing.Size(76, 36);
            this.btnSalvarDia.TabIndex = 11;
            this.btnSalvarDia.Text = "Salvar";
            this.btnSalvarDia.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSalvarDia.UseAccentColor = false;
            this.btnSalvarDia.UseVisualStyleBackColor = true;
            this.btnSalvarDia.Click += new System.EventHandler(this.btnSalvarDia_Click);
            // 
            // listDia
            // 
            this.listDia.BackColor = System.Drawing.Color.White;
            this.listDia.BorderColor = System.Drawing.Color.LightGray;
            this.listDia.Depth = 0;
            this.listDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listDia.Location = new System.Drawing.Point(352, 80);
            this.listDia.MouseState = MaterialSkin.MouseState.HOVER;
            this.listDia.Name = "listDia";
            this.listDia.SelectedIndex = -1;
            this.listDia.SelectedItem = null;
            this.listDia.Size = new System.Drawing.Size(421, 290);
            this.listDia.TabIndex = 12;
            // 
            // numericUpDownDia
            // 
            this.numericUpDownDia.Location = new System.Drawing.Point(27, 176);
            this.numericUpDownDia.Name = "numericUpDownDia";
            this.numericUpDownDia.Size = new System.Drawing.Size(300, 22);
            this.numericUpDownDia.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Dia";
            // 
            // cmbLivro
            // 
            this.cmbLivro.AutoResize = false;
            this.cmbLivro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbLivro.Depth = 0;
            this.cmbLivro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbLivro.DropDownHeight = 118;
            this.cmbLivro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLivro.DropDownWidth = 121;
            this.cmbLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbLivro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbLivro.FormattingEnabled = true;
            this.cmbLivro.IntegralHeight = false;
            this.cmbLivro.ItemHeight = 29;
            this.cmbLivro.Location = new System.Drawing.Point(27, 215);
            this.cmbLivro.MaxDropDownItems = 4;
            this.cmbLivro.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbLivro.Name = "cmbLivro";
            this.cmbLivro.Size = new System.Drawing.Size(253, 35);
            this.cmbLivro.StartIndex = 0;
            this.cmbLivro.TabIndex = 15;
            this.cmbLivro.UseTallSize = false;
            // 
            // cmbCapitulo
            // 
            this.cmbCapitulo.AutoResize = false;
            this.cmbCapitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbCapitulo.Depth = 0;
            this.cmbCapitulo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbCapitulo.DropDownHeight = 118;
            this.cmbCapitulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCapitulo.DropDownWidth = 121;
            this.cmbCapitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbCapitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbCapitulo.FormattingEnabled = true;
            this.cmbCapitulo.IntegralHeight = false;
            this.cmbCapitulo.ItemHeight = 29;
            this.cmbCapitulo.Location = new System.Drawing.Point(27, 269);
            this.cmbCapitulo.MaxDropDownItems = 4;
            this.cmbCapitulo.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbCapitulo.Name = "cmbCapitulo";
            this.cmbCapitulo.Size = new System.Drawing.Size(101, 35);
            this.cmbCapitulo.StartIndex = 0;
            this.cmbCapitulo.TabIndex = 16;
            this.cmbCapitulo.UseTallSize = false;
            // 
            // btnVoltarTelaAdmin
            // 
            this.btnVoltarTelaAdmin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnVoltarTelaAdmin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnVoltarTelaAdmin.Depth = 0;
            this.btnVoltarTelaAdmin.HighEmphasis = true;
            this.btnVoltarTelaAdmin.Icon = null;
            this.btnVoltarTelaAdmin.Location = new System.Drawing.Point(697, 395);
            this.btnVoltarTelaAdmin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnVoltarTelaAdmin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnVoltarTelaAdmin.Name = "btnVoltarTelaAdmin";
            this.btnVoltarTelaAdmin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnVoltarTelaAdmin.Size = new System.Drawing.Size(92, 36);
            this.btnVoltarTelaAdmin.TabIndex = 17;
            this.btnVoltarTelaAdmin.Text = "<- Voltar";
            this.btnVoltarTelaAdmin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnVoltarTelaAdmin.UseAccentColor = false;
            this.btnVoltarTelaAdmin.UseVisualStyleBackColor = true;
            this.btnVoltarTelaAdmin.Click += new System.EventHandler(this.btnVoltarTelaAdmin_Click);
            // 
            // picBtnProximoDia
            // 
            this.picBtnProximoDia.Image = ((System.Drawing.Image)(resources.GetObject("picBtnProximoDia.Image")));
            this.picBtnProximoDia.Location = new System.Drawing.Point(250, 80);
            this.picBtnProximoDia.Name = "picBtnProximoDia";
            this.picBtnProximoDia.Size = new System.Drawing.Size(77, 47);
            this.picBtnProximoDia.TabIndex = 18;
            this.picBtnProximoDia.TabStop = false;
            this.picBtnProximoDia.Click += new System.EventHandler(this.picBtnProximoDia_Click);
            // 
            // picBtnAnteriorDia
            // 
            this.picBtnAnteriorDia.Image = ((System.Drawing.Image)(resources.GetObject("picBtnAnteriorDia.Image")));
            this.picBtnAnteriorDia.Location = new System.Drawing.Point(26, 80);
            this.picBtnAnteriorDia.Name = "picBtnAnteriorDia";
            this.picBtnAnteriorDia.Size = new System.Drawing.Size(77, 47);
            this.picBtnAnteriorDia.TabIndex = 19;
            this.picBtnAnteriorDia.TabStop = false;
            this.picBtnAnteriorDia.Click += new System.EventHandler(this.picBtnAnteriorDia_Click);
            // 
            // FormPlanoDiasAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picBtnAnteriorDia);
            this.Controls.Add(this.picBtnProximoDia);
            this.Controls.Add(this.btnVoltarTelaAdmin);
            this.Controls.Add(this.cmbCapitulo);
            this.Controls.Add(this.cmbLivro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownDia);
            this.Controls.Add(this.listDia);
            this.Controls.Add(this.btnSalvarDia);
            this.Name = "FormPlanoDiasAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPlanoDiasAdmin";
            this.Click += new System.EventHandler(this.btnSalvarDia_Click);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnProximoDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnAnteriorDia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnSalvarDia;
        private MaterialSkin.Controls.MaterialListBox listDia;
        private System.Windows.Forms.NumericUpDown numericUpDownDia;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialComboBox cmbLivro;
        private MaterialSkin.Controls.MaterialComboBox cmbCapitulo;
        private MaterialSkin.Controls.MaterialButton btnVoltarTelaAdmin;
        private System.Windows.Forms.PictureBox picBtnProximoDia;
        private System.Windows.Forms.PictureBox picBtnAnteriorDia;
    }
}