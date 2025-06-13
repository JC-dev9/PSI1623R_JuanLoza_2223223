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
            this.txtDia = new MaterialSkin.Controls.MaterialTextBox();
            this.txtCapitulos = new MaterialSkin.Controls.MaterialTextBox();
            this.btnSalvarDia = new MaterialSkin.Controls.MaterialButton();
            this.listDias = new MaterialSkin.Controls.MaterialListBox();
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
            this.cmbPlanos.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbPlanos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbPlanos.FormattingEnabled = true;
            this.cmbPlanos.IntegralHeight = false;
            this.cmbPlanos.ItemHeight = 43;
            this.cmbPlanos.Location = new System.Drawing.Point(27, 80);
            this.cmbPlanos.MaxDropDownItems = 4;
            this.cmbPlanos.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbPlanos.Name = "cmbPlanos";
            this.cmbPlanos.Size = new System.Drawing.Size(121, 49);
            this.cmbPlanos.StartIndex = 0;
            this.cmbPlanos.TabIndex = 0;
            // 
            // txtDia
            // 
            this.txtDia.AnimateReadOnly = false;
            this.txtDia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDia.CausesValidation = false;
            this.txtDia.Depth = 0;
            this.txtDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDia.Hint = "Dia";
            this.txtDia.LeadingIcon = null;
            this.txtDia.Location = new System.Drawing.Point(27, 160);
            this.txtDia.MaxLength = 50;
            this.txtDia.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDia.Multiline = false;
            this.txtDia.Name = "txtDia";
            this.txtDia.Size = new System.Drawing.Size(300, 50);
            this.txtDia.TabIndex = 9;
            this.txtDia.Text = "";
            this.txtDia.TrailingIcon = null;
            // 
            // txtCapitulos
            // 
            this.txtCapitulos.AnimateReadOnly = false;
            this.txtCapitulos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCapitulos.CausesValidation = false;
            this.txtCapitulos.Depth = 0;
            this.txtCapitulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCapitulos.Hint = "Capitulos";
            this.txtCapitulos.LeadingIcon = null;
            this.txtCapitulos.Location = new System.Drawing.Point(27, 225);
            this.txtCapitulos.MaxLength = 50;
            this.txtCapitulos.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCapitulos.Multiline = false;
            this.txtCapitulos.Name = "txtCapitulos";
            this.txtCapitulos.Size = new System.Drawing.Size(300, 50);
            this.txtCapitulos.TabIndex = 10;
            this.txtCapitulos.Text = "";
            this.txtCapitulos.TrailingIcon = null;
            // 
            // btnSalvarDia
            // 
            this.btnSalvarDia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSalvarDia.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSalvarDia.Depth = 0;
            this.btnSalvarDia.HighEmphasis = true;
            this.btnSalvarDia.Icon = null;
            this.btnSalvarDia.Location = new System.Drawing.Point(27, 297);
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
            // 
            // listDias
            // 
            this.listDias.BackColor = System.Drawing.Color.White;
            this.listDias.BorderColor = System.Drawing.Color.LightGray;
            this.listDias.Depth = 0;
            this.listDias.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listDias.Location = new System.Drawing.Point(456, 121);
            this.listDias.MouseState = MaterialSkin.MouseState.HOVER;
            this.listDias.Name = "listDias";
            this.listDias.SelectedIndex = -1;
            this.listDias.SelectedItem = null;
            this.listDias.Size = new System.Drawing.Size(240, 118);
            this.listDias.TabIndex = 12;
            // 
            // FormPlanoDiasAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listDias);
            this.Controls.Add(this.btnSalvarDia);
            this.Controls.Add(this.txtCapitulos);
            this.Controls.Add(this.txtDia);
            this.Controls.Add(this.cmbPlanos);
            this.Name = "FormPlanoDiasAdmin";
            this.Text = "FormPlanoDiasAdmin";
            this.Click += new System.EventHandler(this.btnSalvarDia_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox cmbPlanos;
        private MaterialSkin.Controls.MaterialTextBox txtDia;
        private MaterialSkin.Controls.MaterialTextBox txtCapitulos;
        private MaterialSkin.Controls.MaterialButton btnSalvarDia;
        private MaterialSkin.Controls.MaterialListBox listDias;
    }
}