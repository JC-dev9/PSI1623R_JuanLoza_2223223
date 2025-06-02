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
            this.tabHome = new System.Windows.Forms.TabPage();
            this.materialCard2 = new MaterialSkin.Controls.MaterialCard();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.cardVersiculoDia = new MaterialSkin.Controls.MaterialCard();
            this.lblTextoVersiculo = new System.Windows.Forms.Label();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.btnSalvarVersiculo = new MaterialSkin.Controls.MaterialButton();
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
            this.pnlChatbot = new System.Windows.Forms.Panel();
            this.btnEnviarChatbot = new MaterialSkin.Controls.MaterialButton();
            this.flowLayoutPanelConversa = new System.Windows.Forms.FlowLayoutPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TabControlPrincipal.SuspendLayout();
            this.tabHome.SuspendLayout();
            this.materialCard2.SuspendLayout();
            this.cardVersiculoDia.SuspendLayout();
            this.tabBible.SuspendLayout();
            this.flowLayoutPanelVersiculos.SuspendLayout();
            this.pnlBible.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAudio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnAnteriorCapitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnProximoCapitulo)).BeginInit();
            this.tabChatbot.SuspendLayout();
            this.pnlChatbot.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlPrincipal
            // 
            this.TabControlPrincipal.Controls.Add(this.tabHome);
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
            // tabHome
            // 
            this.tabHome.BackColor = System.Drawing.Color.White;
            this.tabHome.Controls.Add(this.materialCard2);
            this.tabHome.Controls.Add(this.cardVersiculoDia);
            this.tabHome.ImageKey = "house.png";
            this.tabHome.Location = new System.Drawing.Point(4, 31);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(866, 395);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            this.tabHome.Click += new System.EventHandler(this.tabHome_Click);
            // 
            // materialCard2
            // 
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.Controls.Add(this.materialButton3);
            this.materialCard2.Controls.Add(this.materialLabel5);
            this.materialCard2.Controls.Add(this.materialLabel4);
            this.materialCard2.Depth = 0;
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(474, 210);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(322, 145);
            this.materialCard2.TabIndex = 1;
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton3.Depth = 0;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = null;
            this.materialButton3.Location = new System.Drawing.Point(183, 93);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton3.Size = new System.Drawing.Size(97, 36);
            this.materialButton3.TabIndex = 2;
            this.materialButton3.Text = "Retornar";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(17, 58);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(107, 19);
            this.materialLabel5.TabIndex = 1;
            this.materialLabel5.Text = "materialLabel5";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(18, 18);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(107, 19);
            this.materialLabel4.TabIndex = 0;
            this.materialLabel4.Text = "materialLabel4";
            // 
            // cardVersiculoDia
            // 
            this.cardVersiculoDia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardVersiculoDia.Controls.Add(this.lblTextoVersiculo);
            this.cardVersiculoDia.Controls.Add(this.materialButton2);
            this.cardVersiculoDia.Controls.Add(this.btnSalvarVersiculo);
            this.cardVersiculoDia.Depth = 0;
            this.cardVersiculoDia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardVersiculoDia.Location = new System.Drawing.Point(17, 17);
            this.cardVersiculoDia.Margin = new System.Windows.Forms.Padding(14);
            this.cardVersiculoDia.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardVersiculoDia.Name = "cardVersiculoDia";
            this.cardVersiculoDia.Padding = new System.Windows.Forms.Padding(14);
            this.cardVersiculoDia.Size = new System.Drawing.Size(429, 338);
            this.cardVersiculoDia.TabIndex = 0;
            this.cardVersiculoDia.Paint += new System.Windows.Forms.PaintEventHandler(this.materialCard1_Paint);
            // 
            // lblTextoVersiculo
            // 
            this.lblTextoVersiculo.AutoSize = true;
            this.lblTextoVersiculo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoVersiculo.Location = new System.Drawing.Point(11, 74);
            this.lblTextoVersiculo.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblTextoVersiculo.Name = "lblTextoVersiculo";
            this.lblTextoVersiculo.Size = new System.Drawing.Size(0, 20);
            this.lblTextoVersiculo.TabIndex = 1;
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(208, 244);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(137, 36);
            this.materialButton2.TabIndex = 4;
            this.materialButton2.Text = "Compartiilhar";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            // 
            // btnSalvarVersiculo
            // 
            this.btnSalvarVersiculo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSalvarVersiculo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSalvarVersiculo.Depth = 0;
            this.btnSalvarVersiculo.HighEmphasis = true;
            this.btnSalvarVersiculo.Icon = null;
            this.btnSalvarVersiculo.Location = new System.Drawing.Point(55, 244);
            this.btnSalvarVersiculo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSalvarVersiculo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSalvarVersiculo.Name = "btnSalvarVersiculo";
            this.btnSalvarVersiculo.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSalvarVersiculo.Size = new System.Drawing.Size(76, 36);
            this.btnSalvarVersiculo.TabIndex = 3;
            this.btnSalvarVersiculo.Text = "Salvar";
            this.btnSalvarVersiculo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSalvarVersiculo.UseAccentColor = false;
            this.btnSalvarVersiculo.UseVisualStyleBackColor = true;
            this.btnSalvarVersiculo.Click += new System.EventHandler(this.btnSalvarVersiculo_Click);
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
            // pnlChatbot
            // 
            this.pnlChatbot.Controls.Add(this.btnEnviarChatbot);
            this.pnlChatbot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChatbot.Location = new System.Drawing.Point(0, 328);
            this.pnlChatbot.Name = "pnlChatbot";
            this.pnlChatbot.Size = new System.Drawing.Size(866, 67);
            this.pnlChatbot.TabIndex = 8;
            // 
            // btnEnviarChatbot
            // 
            this.btnEnviarChatbot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviarChatbot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEnviarChatbot.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEnviarChatbot.Depth = 0;
            this.btnEnviarChatbot.HighEmphasis = true;
            this.btnEnviarChatbot.Icon = null;
            this.btnEnviarChatbot.Location = new System.Drawing.Point(696, 17);
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
            this.tabHome.ResumeLayout(false);
            this.materialCard2.ResumeLayout(false);
            this.materialCard2.PerformLayout();
            this.cardVersiculoDia.ResumeLayout(false);
            this.cardVersiculoDia.PerformLayout();
            this.tabBible.ResumeLayout(false);
            this.flowLayoutPanelVersiculos.ResumeLayout(false);
            this.pnlBible.ResumeLayout(false);
            this.pnlBible.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAudio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnAnteriorCapitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnProximoCapitulo)).EndInit();
            this.tabChatbot.ResumeLayout(false);
            this.pnlChatbot.ResumeLayout(false);
            this.pnlChatbot.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl TabControlPrincipal;
        private System.Windows.Forms.TabPage tabHome;
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
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialCard cardVersiculoDia;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialButton btnSalvarVersiculo;
        private Label lblTextoVersiculo;
    }
}