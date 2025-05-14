using System.Drawing;
using System.Windows.Forms;

namespace BeLightBible
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabBible = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelVersiculos = new System.Windows.Forms.FlowLayoutPanel();
            this.richTextBoxVersiculos = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new MaterialSkin.Controls.MaterialButton();
            this.cmbLivro = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbCapitulo = new MaterialSkin.Controls.MaterialComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.materialTabControl1.SuspendLayout();
            this.tabBible.SuspendLayout();
            this.flowLayoutPanelVersiculos.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabBible);
            this.materialTabControl1.Controls.Add(this.tabPage3);
            this.materialTabControl1.Controls.Add(this.tabPage4);
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
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.ImageKey = "house.png";
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(804, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            // 
            // tabBible
            // 
            this.tabBible.Controls.Add(this.flowLayoutPanelVersiculos);
            this.tabBible.Controls.Add(this.panel1);
            this.tabBible.ImageKey = "book-marked(1).png";
            this.tabBible.Location = new System.Drawing.Point(4, 31);
            this.tabBible.Name = "tabBible";
            this.tabBible.Padding = new System.Windows.Forms.Padding(3);
            this.tabBible.Size = new System.Drawing.Size(804, 395);
            this.tabBible.TabIndex = 1;
            this.tabBible.Text = "Bíblia";
            this.tabBible.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelVersiculos
            // 
            this.flowLayoutPanelVersiculos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelVersiculos.AutoScroll = true;
            this.flowLayoutPanelVersiculos.Controls.Add(this.richTextBoxVersiculos);
            this.flowLayoutPanelVersiculos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelVersiculos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanelVersiculos.Location = new System.Drawing.Point(3, 62);
            this.flowLayoutPanelVersiculos.Margin = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.flowLayoutPanelVersiculos.Name = "flowLayoutPanelVersiculos";
            this.flowLayoutPanelVersiculos.Padding = new System.Windows.Forms.Padding(6, 25, 0, 0);
            this.flowLayoutPanelVersiculos.Size = new System.Drawing.Size(798, 330);
            this.flowLayoutPanelVersiculos.TabIndex = 0;
            this.flowLayoutPanelVersiculos.WrapContents = false;
            // 
            // richTextBoxVersiculos
            // 
            this.richTextBoxVersiculos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.richTextBoxVersiculos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxVersiculos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxVersiculos.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.richTextBoxVersiculos.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBoxVersiculos.Location = new System.Drawing.Point(9, 28);
            this.richTextBoxVersiculos.Name = "richTextBoxVersiculos";
            this.richTextBoxVersiculos.ReadOnly = true;
            this.richTextBoxVersiculos.Size = new System.Drawing.Size(0, 0);
            this.richTextBoxVersiculos.TabIndex = 0;
            this.richTextBoxVersiculos.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.cmbLivro);
            this.panel1.Controls.Add(this.cmbCapitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 59);
            this.panel1.TabIndex = 5;
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBuscar.Depth = 0;
            this.btnBuscar.HighEmphasis = true;
            this.btnBuscar.Icon = null;
            this.btnBuscar.Location = new System.Drawing.Point(395, 8);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBuscar.Size = new System.Drawing.Size(77, 36);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBuscar.UseAccentColor = false;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.cmbLivro.Location = new System.Drawing.Point(3, 9);
            this.cmbLivro.MaxDropDownItems = 4;
            this.cmbLivro.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbLivro.Name = "cmbLivro";
            this.cmbLivro.Size = new System.Drawing.Size(253, 35);
            this.cmbLivro.StartIndex = 0;
            this.cmbLivro.TabIndex = 1;
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
            this.cmbCapitulo.Location = new System.Drawing.Point(275, 9);
            this.cmbCapitulo.MaxDropDownItems = 4;
            this.cmbCapitulo.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbCapitulo.Name = "cmbCapitulo";
            this.cmbCapitulo.Size = new System.Drawing.Size(101, 35);
            this.cmbCapitulo.StartIndex = 0;
            this.cmbCapitulo.TabIndex = 2;
            this.cmbCapitulo.UseTallSize = false;
            // 
            // tabPage3
            // 
            this.tabPage3.ImageKey = "notepad-text.png";
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(804, 395);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Notebook";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.ImageKey = "bot.png";
            this.tabPage4.Location = new System.Drawing.Point(4, 31);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(804, 395);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Settings";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "notepad-text.png");
            this.imageList1.Images.SetKeyName(1, "bot.png");
            this.imageList1.Images.SetKeyName(2, "book-marked(1).png");
            this.imageList1.Images.SetKeyName(3, "house.png");
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 497);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BeLight Bible";
            this.materialTabControl1.ResumeLayout(false);
            this.tabBible.ResumeLayout(false);
            this.flowLayoutPanelVersiculos.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabBible;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelVersiculos;
        private MaterialSkin.Controls.MaterialComboBox cmbLivro;
        private MaterialSkin.Controls.MaterialButton btnBuscar;
        private MaterialSkin.Controls.MaterialComboBox cmbCapitulo;
        private RichTextBox richTextBoxVersiculos;
        private Panel panel1;
    }
}