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
            this.cmbPlanos = new MaterialSkin.Controls.MaterialComboBox();
            this.btnSalvarDia = new MaterialSkin.Controls.MaterialButton();
            this.listDias = new MaterialSkin.Controls.MaterialListBox();
            this.numericUpDownDia = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLivro = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbCapitulo = new MaterialSkin.Controls.MaterialComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDia)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPlanos
            // 
            this.cmbPlanos.AutoResize = false;
            this.cmbPlanos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbPlanos.Depth = 0;
            this.cmbPlanos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbPlanos.DropDownHeight = 174;
            this.cmbPlanos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanos.DropDownWidth = 121;
            this.cmbPlanos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbPlanos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbPlanos.FormattingEnabled = true;
            this.cmbPlanos.IntegralHeight = false;
            this.cmbPlanos.ItemHeight = 43;
            this.cmbPlanos.Location = new System.Drawing.Point(27, 80);
            this.cmbPlanos.MaxDropDownItems = 4;
            this.cmbPlanos.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbPlanos.Name = "cmbPlanos";
            this.cmbPlanos.Size = new System.Drawing.Size(300, 49);
            this.cmbPlanos.StartIndex = 0;
            this.cmbPlanos.TabIndex = 0;
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
            // listDias
            // 
            this.listDias.BackColor = System.Drawing.Color.White;
            this.listDias.BorderColor = System.Drawing.Color.LightGray;
            this.listDias.Depth = 0;
            this.listDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listDias.Location = new System.Drawing.Point(352, 80);
            this.listDias.MouseState = MaterialSkin.MouseState.HOVER;
            this.listDias.Name = "listDias";
            this.listDias.SelectedIndex = -1;
            this.listDias.SelectedItem = null;
            this.listDias.Size = new System.Drawing.Size(421, 290);
            this.listDias.TabIndex = 12;
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
            // FormPlanoDiasAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbCapitulo);
            this.Controls.Add(this.cmbLivro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownDia);
            this.Controls.Add(this.listDias);
            this.Controls.Add(this.btnSalvarDia);
            this.Controls.Add(this.cmbPlanos);
            this.Name = "FormPlanoDiasAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPlanoDiasAdmin";
            this.Click += new System.EventHandler(this.btnSalvarDia_Click);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox cmbPlanos;
        private MaterialSkin.Controls.MaterialButton btnSalvarDia;
        private MaterialSkin.Controls.MaterialListBox listDias;
        private System.Windows.Forms.NumericUpDown numericUpDownDia;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialComboBox cmbLivro;
        private MaterialSkin.Controls.MaterialComboBox cmbCapitulo;
    }
}