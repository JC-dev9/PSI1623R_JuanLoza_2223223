namespace BeLightBible
{
    partial class MenuAdmin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuAdmin));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabCriarPlano = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelPlanos = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlCategoriaPlano = new System.Windows.Forms.Panel();
            this.btnCriarPlano = new MaterialSkin.Controls.MaterialButton();
            this.materialTabControl1.SuspendLayout();
            this.tabCriarPlano.SuspendLayout();
            this.pnlCategoriaPlano.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "auto_stories_24dp_E3E3E3_FILL0_wght400_GRAD0_opsz24(1).png");
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabCriarPlano);
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.imageList1;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(812, 430);
            this.materialTabControl1.TabIndex = 0;
            // 
            // tabCriarPlano
            // 
            this.tabCriarPlano.Controls.Add(this.pnlCategoriaPlano);
            this.tabCriarPlano.Controls.Add(this.flowLayoutPanelPlanos);
            this.tabCriarPlano.ImageKey = "auto_stories_24dp_E3E3E3_FILL0_wght400_GRAD0_opsz24(1).png";
            this.tabCriarPlano.Location = new System.Drawing.Point(4, 31);
            this.tabCriarPlano.Name = "tabCriarPlano";
            this.tabCriarPlano.Padding = new System.Windows.Forms.Padding(3);
            this.tabCriarPlano.Size = new System.Drawing.Size(804, 395);
            this.tabCriarPlano.TabIndex = 0;
            this.tabCriarPlano.Text = "Plano de Leitura";
            this.tabCriarPlano.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelPlanos
            // 
            this.flowLayoutPanelPlanos.AutoScroll = true;
            this.flowLayoutPanelPlanos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelPlanos.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelPlanos.Name = "flowLayoutPanelPlanos";
            this.flowLayoutPanelPlanos.Size = new System.Drawing.Size(798, 389);
            this.flowLayoutPanelPlanos.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(804, 395);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlCategoriaPlano
            // 
            this.pnlCategoriaPlano.BackColor = System.Drawing.Color.Transparent;
            this.pnlCategoriaPlano.Controls.Add(this.btnCriarPlano);
            this.pnlCategoriaPlano.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCategoriaPlano.ForeColor = System.Drawing.SystemColors.GrayText;
            this.pnlCategoriaPlano.Location = new System.Drawing.Point(3, 3);
            this.pnlCategoriaPlano.Name = "pnlCategoriaPlano";
            this.pnlCategoriaPlano.Size = new System.Drawing.Size(798, 59);
            this.pnlCategoriaPlano.TabIndex = 10;
            // 
            // btnCriarPlano
            // 
            this.btnCriarPlano.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCriarPlano.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCriarPlano.Depth = 0;
            this.btnCriarPlano.HighEmphasis = true;
            this.btnCriarPlano.Icon = null;
            this.btnCriarPlano.Location = new System.Drawing.Point(18, 11);
            this.btnCriarPlano.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCriarPlano.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCriarPlano.Name = "btnCriarPlano";
            this.btnCriarPlano.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCriarPlano.Size = new System.Drawing.Size(159, 36);
            this.btnCriarPlano.TabIndex = 0;
            this.btnCriarPlano.Text = "Criar novo plano";
            this.btnCriarPlano.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCriarPlano.UseAccentColor = false;
            this.btnCriarPlano.UseVisualStyleBackColor = true;
            this.btnCriarPlano.Click += new System.EventHandler(this.btnCriarPlano_Click);
            // 
            // MenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 497);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerTabControl = this.materialTabControl1;
            this.Name = "MenuAdmin";
            this.Text = "MenuAdmin";
            this.Load += new System.EventHandler(this.MenuAdmin_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.tabCriarPlano.ResumeLayout(false);
            this.pnlCategoriaPlano.ResumeLayout(false);
            this.pnlCategoriaPlano.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabCriarPlano;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPlanos;
        private System.Windows.Forms.Panel pnlCategoriaPlano;
        private MaterialSkin.Controls.MaterialButton btnCriarPlano;
    }
}