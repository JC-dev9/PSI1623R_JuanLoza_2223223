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
            this.TabControlPrincipal = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabBible = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelVersiculos = new System.Windows.Forms.FlowLayoutPanel();
            this.richTextBoxVersiculos = new System.Windows.Forms.RichTextBox();
            this.pnlBible = new System.Windows.Forms.Panel();
            this.picAudio = new System.Windows.Forms.PictureBox();
            this.picBtnAnteriorCapitulo = new System.Windows.Forms.PictureBox();
            this.picBtnProximoCapitulo = new System.Windows.Forms.PictureBox();
            this.btnBuscar = new MaterialSkin.Controls.MaterialButton();
            this.cmbLivro = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbCapitulo = new MaterialSkin.Controls.MaterialComboBox();
            this.tabChatbot = new System.Windows.Forms.TabPage();
            this.txtPergunta = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnEnviarChatbot = new MaterialSkin.Controls.MaterialButton();
            this.pnlChatbot = new System.Windows.Forms.Panel();
            this.flowLayoutPanelConversa = new System.Windows.Forms.FlowLayoutPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TabControlPrincipal.SuspendLayout();
            this.tabBible.SuspendLayout();
            this.flowLayoutPanelVersiculos.SuspendLayout();
            this.pnlBible.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAudio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnAnteriorCapitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnProximoCapitulo)).BeginInit();
            this.tabChatbot.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlPrincipal
            // 
            this.TabControlPrincipal.Controls.Add(this.tabPage1);
            this.TabControlPrincipal.Controls.Add(this.tabBible);
            this.TabControlPrincipal.Controls.Add(this.tabChatbot);
            this.TabControlPrincipal.Depth = 0;
            this.TabControlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlPrincipal.ImageList = this.imageList1;
            this.TabControlPrincipal.Location = new System.Drawing.Point(3, 64);
            this.TabControlPrincipal.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabControlPrincipal.Multiline = true;
            this.TabControlPrincipal.Name = "TabControlPrincipal";
            this.TabControlPrincipal.SelectedIndex = 0;
            this.TabControlPrincipal.Size = new System.Drawing.Size(874, 430);
            this.TabControlPrincipal.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.ImageKey = "house.png";
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(866, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            // 
            // tabBible
            // 
            this.tabBible.Controls.Add(this.flowLayoutPanelVersiculos);
            this.tabBible.Controls.Add(this.pnlBible);
            this.tabBible.ImageKey = "book-marked(1).png";
            this.tabBible.Location = new System.Drawing.Point(4, 31);
            this.tabBible.Name = "tabBible";
            this.tabBible.Padding = new System.Windows.Forms.Padding(3);
            this.tabBible.Size = new System.Drawing.Size(866, 395);
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
            this.flowLayoutPanelVersiculos.Size = new System.Drawing.Size(654, 330);
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
            // pnlBible
            // 
            this.pnlBible.BackColor = System.Drawing.Color.Transparent;
            this.pnlBible.Controls.Add(this.picAudio);
            this.pnlBible.Controls.Add(this.picBtnAnteriorCapitulo);
            this.pnlBible.Controls.Add(this.picBtnProximoCapitulo);
            this.pnlBible.Controls.Add(this.btnBuscar);
            this.pnlBible.Controls.Add(this.cmbLivro);
            this.pnlBible.Controls.Add(this.cmbCapitulo);
            this.pnlBible.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBible.ForeColor = System.Drawing.SystemColors.GrayText;
            this.pnlBible.Location = new System.Drawing.Point(3, 3);
            this.pnlBible.Name = "pnlBible";
            this.pnlBible.Size = new System.Drawing.Size(860, 59);
            this.pnlBible.TabIndex = 5;
            // 
            // picAudio
            // 
            this.picAudio.Image = ((System.Drawing.Image)(resources.GetObject("picAudio.Image")));
            this.picAudio.Location = new System.Drawing.Point(512, 5);
            this.picAudio.Name = "picAudio";
            this.picAudio.Size = new System.Drawing.Size(77, 47);
            this.picAudio.TabIndex = 7;
            this.picAudio.TabStop = false;
            this.picAudio.Click += new System.EventHandler(this.picAudio_Click);
            // 
            // picBtnAnteriorCapitulo
            // 
            this.picBtnAnteriorCapitulo.Image = ((System.Drawing.Image)(resources.GetObject("picBtnAnteriorCapitulo.Image")));
            this.picBtnAnteriorCapitulo.Location = new System.Drawing.Point(608, 5);
            this.picBtnAnteriorCapitulo.Name = "picBtnAnteriorCapitulo";
            this.picBtnAnteriorCapitulo.Size = new System.Drawing.Size(77, 47);
            this.picBtnAnteriorCapitulo.TabIndex = 6;
            this.picBtnAnteriorCapitulo.TabStop = false;
            // 
            // picBtnProximoCapitulo
            // 
            this.picBtnProximoCapitulo.Image = ((System.Drawing.Image)(resources.GetObject("picBtnProximoCapitulo.Image")));
            this.picBtnProximoCapitulo.Location = new System.Drawing.Point(705, 5);
            this.picBtnProximoCapitulo.Name = "picBtnProximoCapitulo";
            this.picBtnProximoCapitulo.Size = new System.Drawing.Size(77, 47);
            this.picBtnProximoCapitulo.TabIndex = 5;
            this.picBtnProximoCapitulo.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBuscar.Depth = 0;
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.GrayText;
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
            // tabChatbot
            // 
            this.tabChatbot.Controls.Add(this.txtPergunta);
            this.tabChatbot.Controls.Add(this.btnEnviarChatbot);
            this.tabChatbot.Controls.Add(this.pnlChatbot);
            this.tabChatbot.Controls.Add(this.flowLayoutPanelConversa);
            this.tabChatbot.ImageKey = "bot.png";
            this.tabChatbot.Location = new System.Drawing.Point(4, 31);
            this.tabChatbot.Name = "tabChatbot";
            this.tabChatbot.Size = new System.Drawing.Size(866, 395);
            this.tabChatbot.TabIndex = 2;
            this.tabChatbot.Text = "Chatbot";
            this.tabChatbot.UseVisualStyleBackColor = true;
            // 
            // txtPergunta
            // 
            this.txtPergunta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPergunta.AnimateReadOnly = false;
            this.txtPergunta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPergunta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPergunta.Depth = 0;
            this.txtPergunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPergunta.HideSelection = true;
            this.txtPergunta.Hint = "Pergunte qualquer coisa";
            this.txtPergunta.LeadingIcon = null;
            this.txtPergunta.Location = new System.Drawing.Point(13, 333);
            this.txtPergunta.MaxLength = 32767;
            this.txtPergunta.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPergunta.Name = "txtPergunta";
            this.txtPergunta.PasswordChar = '\0';
            this.txtPergunta.PrefixSuffixText = null;
            this.txtPergunta.ReadOnly = false;
            this.txtPergunta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPergunta.SelectedText = "";
            this.txtPergunta.SelectionLength = 0;
            this.txtPergunta.SelectionStart = 0;
            this.txtPergunta.ShortcutsEnabled = true;
            this.txtPergunta.Size = new System.Drawing.Size(617, 48);
            this.txtPergunta.TabIndex = 0;
            this.txtPergunta.TabStop = false;
            this.txtPergunta.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPergunta.TrailingIcon = null;
            this.txtPergunta.UseSystemPasswordChar = false;
            // 
            // btnEnviarChatbot
            // 
            this.btnEnviarChatbot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviarChatbot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEnviarChatbot.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEnviarChatbot.Depth = 0;
            this.btnEnviarChatbot.HighEmphasis = true;
            this.btnEnviarChatbot.Icon = null;
            this.btnEnviarChatbot.Location = new System.Drawing.Point(652, 345);
            this.btnEnviarChatbot.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEnviarChatbot.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEnviarChatbot.Name = "btnEnviarChatbot";
            this.btnEnviarChatbot.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEnviarChatbot.Size = new System.Drawing.Size(73, 36);
            this.btnEnviarChatbot.TabIndex = 7;
            this.btnEnviarChatbot.Text = "Enviar";
            this.btnEnviarChatbot.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEnviarChatbot.UseAccentColor = false;
            this.btnEnviarChatbot.UseVisualStyleBackColor = true;
            this.btnEnviarChatbot.Click += new System.EventHandler(this.btnEnviarChatbot_Click);
            // 
            // pnlChatbot
            // 
            this.pnlChatbot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChatbot.Location = new System.Drawing.Point(0, 328);
            this.pnlChatbot.Name = "pnlChatbot";
            this.pnlChatbot.Size = new System.Drawing.Size(866, 67);
            this.pnlChatbot.TabIndex = 8;
            // 
            // flowLayoutPanelConversa
            // 
            this.flowLayoutPanelConversa.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelConversa.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelConversa.Name = "flowLayoutPanelConversa";
            this.flowLayoutPanelConversa.Size = new System.Drawing.Size(860, 324);
            this.flowLayoutPanelConversa.TabIndex = 6;
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
            this.ClientSize = new System.Drawing.Size(880, 497);
            this.Controls.Add(this.TabControlPrincipal);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.TabControlPrincipal;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BeLight Bible";
            this.TabControlPrincipal.ResumeLayout(false);
            this.tabBible.ResumeLayout(false);
            this.flowLayoutPanelVersiculos.ResumeLayout(false);
            this.pnlBible.ResumeLayout(false);
            this.pnlBible.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAudio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnAnteriorCapitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnProximoCapitulo)).EndInit();
            this.tabChatbot.ResumeLayout(false);
            this.tabChatbot.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl TabControlPrincipal;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabBible;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabChatbot;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelVersiculos;
        private MaterialSkin.Controls.MaterialComboBox cmbLivro;
        private MaterialSkin.Controls.MaterialButton btnBuscar;
        private MaterialSkin.Controls.MaterialComboBox cmbCapitulo;
        private RichTextBox richTextBoxVersiculos;
        private Panel pnlBible;
        private PictureBox picBtnProximoCapitulo;
        private PictureBox picBtnAnteriorCapitulo;
        private PictureBox picAudio;
        private FlowLayoutPanel flowLayoutPanelConversa;
        private MaterialSkin.Controls.MaterialTextBox2 txtPergunta;
        private MaterialSkin.Controls.MaterialButton btnEnviarChatbot;
        private Panel pnlChatbot;
    }
}