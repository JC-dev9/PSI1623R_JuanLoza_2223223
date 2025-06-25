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
            this.cardUltimaLeitura = new MaterialSkin.Controls.MaterialCard();
            this.btnRetomarLeitura = new MaterialSkin.Controls.MaterialButton();
            this.cardVersiculoDia = new MaterialSkin.Controls.MaterialCard();
            this.lblTextoVersiculo = new System.Windows.Forms.Label();
            this.btnCompartilharVersiculo = new MaterialSkin.Controls.MaterialButton();
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
            this.tabAnotacoes = new System.Windows.Forms.TabPage();
            this.pnlAnotacoes = new System.Windows.Forms.Panel();
            this.cmbCategoriaAnotacoes = new MaterialSkin.Controls.MaterialComboBox();
            this.flowLayoutPanelAnotacoes = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPlanoLeitura = new System.Windows.Forms.TabPage();
            this.flowPanelPlanos = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCategoriaPlano = new System.Windows.Forms.Panel();
            this.cmbCategoriaPlanos = new MaterialSkin.Controls.MaterialComboBox();
            this.tabBibleKids = new System.Windows.Forms.TabPage();
            this.pnlBibleKidPrincipal = new System.Windows.Forms.Panel();
            this.cardTextoHistoria = new MaterialSkin.Controls.MaterialCard();
            this.pictureBoxImagemHistoria = new System.Windows.Forms.PictureBox();
            this.pnlBibleKids = new System.Windows.Forms.Panel();
            this.picBtnVoltarHistoria = new System.Windows.Forms.PictureBox();
            this.picBtnProximaHistoria = new System.Windows.Forms.PictureBox();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.gbSessao = new System.Windows.Forms.GroupBox();
            this.btnLogout = new MaterialSkin.Controls.MaterialButton();
            this.SwitchManterSessao = new MaterialSkin.Controls.MaterialSwitch();
            this.gbFonteTamanho = new System.Windows.Forms.GroupBox();
            this.switchTema = new MaterialSkin.Controls.MaterialSwitch();
            this.numericTamanho = new System.Windows.Forms.NumericUpDown();
            this.lblTamanho = new MaterialSkin.Controls.MaterialLabel();
            this.cmbFonte = new MaterialSkin.Controls.MaterialComboBox();
            this.lblFonte = new MaterialSkin.Controls.MaterialLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TabControlPrincipal.SuspendLayout();
            this.tabHome.SuspendLayout();
            this.cardUltimaLeitura.SuspendLayout();
            this.cardVersiculoDia.SuspendLayout();
            this.tabBible.SuspendLayout();
            this.flowLayoutPanelVersiculos.SuspendLayout();
            this.pnlBible.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAudio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnAnteriorCapitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnProximoCapitulo)).BeginInit();
            this.tabChatbot.SuspendLayout();
            this.pnlChatbot.SuspendLayout();
            this.tabAnotacoes.SuspendLayout();
            this.pnlAnotacoes.SuspendLayout();
            this.tabPlanoLeitura.SuspendLayout();
            this.pnlCategoriaPlano.SuspendLayout();
            this.tabBibleKids.SuspendLayout();
            this.pnlBibleKidPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagemHistoria)).BeginInit();
            this.pnlBibleKids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnVoltarHistoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnProximaHistoria)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.gbSessao.SuspendLayout();
            this.gbFonteTamanho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTamanho)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControlPrincipal
            // 
            this.TabControlPrincipal.Controls.Add(this.tabHome);
            this.TabControlPrincipal.Controls.Add(this.tabBible);
            this.TabControlPrincipal.Controls.Add(this.tabChatbot);
            this.TabControlPrincipal.Controls.Add(this.tabAnotacoes);
            this.TabControlPrincipal.Controls.Add(this.tabPlanoLeitura);
            this.TabControlPrincipal.Controls.Add(this.tabBibleKids);
            this.TabControlPrincipal.Controls.Add(this.tabSettings);
            this.TabControlPrincipal.Depth = 0;
            this.TabControlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlPrincipal.ImageList = this.imageList1;
            this.TabControlPrincipal.Location = new System.Drawing.Point(3, 64);
            this.TabControlPrincipal.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabControlPrincipal.Multiline = true;
            this.TabControlPrincipal.Name = "TabControlPrincipal";
            this.TabControlPrincipal.SelectedIndex = 0;
            this.TabControlPrincipal.Size = new System.Drawing.Size(899, 443);
            this.TabControlPrincipal.TabIndex = 0;
            // 
            // tabHome
            // 
            this.tabHome.BackColor = System.Drawing.Color.White;
            this.tabHome.Controls.Add(this.cardUltimaLeitura);
            this.tabHome.Controls.Add(this.cardVersiculoDia);
            this.tabHome.ImageKey = "house.png";
            this.tabHome.Location = new System.Drawing.Point(4, 31);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(891, 408);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            // 
            // cardUltimaLeitura
            // 
            this.cardUltimaLeitura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardUltimaLeitura.Controls.Add(this.btnRetomarLeitura);
            this.cardUltimaLeitura.Depth = 0;
            this.cardUltimaLeitura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardUltimaLeitura.Location = new System.Drawing.Point(474, 210);
            this.cardUltimaLeitura.Margin = new System.Windows.Forms.Padding(14);
            this.cardUltimaLeitura.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardUltimaLeitura.Name = "cardUltimaLeitura";
            this.cardUltimaLeitura.Padding = new System.Windows.Forms.Padding(14);
            this.cardUltimaLeitura.Size = new System.Drawing.Size(322, 145);
            this.cardUltimaLeitura.TabIndex = 1;
            // 
            // btnRetomarLeitura
            // 
            this.btnRetomarLeitura.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRetomarLeitura.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRetomarLeitura.Depth = 0;
            this.btnRetomarLeitura.HighEmphasis = true;
            this.btnRetomarLeitura.Icon = null;
            this.btnRetomarLeitura.Location = new System.Drawing.Point(183, 93);
            this.btnRetomarLeitura.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRetomarLeitura.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRetomarLeitura.Name = "btnRetomarLeitura";
            this.btnRetomarLeitura.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRetomarLeitura.Size = new System.Drawing.Size(97, 36);
            this.btnRetomarLeitura.TabIndex = 2;
            this.btnRetomarLeitura.Text = "Retornar";
            this.btnRetomarLeitura.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRetomarLeitura.UseAccentColor = false;
            this.btnRetomarLeitura.UseVisualStyleBackColor = true;
            this.btnRetomarLeitura.Click += new System.EventHandler(this.btnRetomarLeitura_Click);
            // 
            // cardVersiculoDia
            // 
            this.cardVersiculoDia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardVersiculoDia.Controls.Add(this.lblTextoVersiculo);
            this.cardVersiculoDia.Controls.Add(this.btnCompartilharVersiculo);
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
            // btnCompartilharVersiculo
            // 
            this.btnCompartilharVersiculo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCompartilharVersiculo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCompartilharVersiculo.Depth = 0;
            this.btnCompartilharVersiculo.HighEmphasis = true;
            this.btnCompartilharVersiculo.Icon = null;
            this.btnCompartilharVersiculo.Location = new System.Drawing.Point(229, 277);
            this.btnCompartilharVersiculo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCompartilharVersiculo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCompartilharVersiculo.Name = "btnCompartilharVersiculo";
            this.btnCompartilharVersiculo.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCompartilharVersiculo.Size = new System.Drawing.Size(137, 36);
            this.btnCompartilharVersiculo.TabIndex = 4;
            this.btnCompartilharVersiculo.Text = "Compartiilhar";
            this.btnCompartilharVersiculo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCompartilharVersiculo.UseAccentColor = false;
            this.btnCompartilharVersiculo.UseVisualStyleBackColor = true;
            this.btnCompartilharVersiculo.Click += new System.EventHandler(this.btnCompartilharVersiculo_Click);
            // 
            // btnSalvarVersiculo
            // 
            this.btnSalvarVersiculo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSalvarVersiculo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSalvarVersiculo.Depth = 0;
            this.btnSalvarVersiculo.HighEmphasis = true;
            this.btnSalvarVersiculo.Icon = null;
            this.btnSalvarVersiculo.Location = new System.Drawing.Point(101, 277);
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
            this.tabBible.ImageKey = "bible.png";
            this.tabBible.Location = new System.Drawing.Point(4, 31);
            this.tabBible.Name = "tabBible";
            this.tabBible.Padding = new System.Windows.Forms.Padding(3);
            this.tabBible.Size = new System.Drawing.Size(891, 408);
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
            this.pnlBible.Size = new System.Drawing.Size(885, 59);
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
            this.tabChatbot.Size = new System.Drawing.Size(891, 408);
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
            this.txtPergunta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPergunta_KeyDown);
            // 
            // pnlChatbot
            // 
            this.pnlChatbot.Controls.Add(this.btnEnviarChatbot);
            this.pnlChatbot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChatbot.Location = new System.Drawing.Point(0, 341);
            this.pnlChatbot.Name = "pnlChatbot";
            this.pnlChatbot.Size = new System.Drawing.Size(891, 67);
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
            this.btnEnviarChatbot.Location = new System.Drawing.Point(721, 17);
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
            this.flowLayoutPanelConversa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelConversa.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelConversa.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelConversa.Name = "flowLayoutPanelConversa";
            this.flowLayoutPanelConversa.Size = new System.Drawing.Size(891, 408);
            this.flowLayoutPanelConversa.TabIndex = 6;
            // 
            // tabAnotacoes
            // 
            this.tabAnotacoes.Controls.Add(this.pnlAnotacoes);
            this.tabAnotacoes.Controls.Add(this.flowLayoutPanelAnotacoes);
            this.tabAnotacoes.ImageKey = "bookmark.png";
            this.tabAnotacoes.Location = new System.Drawing.Point(4, 31);
            this.tabAnotacoes.Name = "tabAnotacoes";
            this.tabAnotacoes.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnotacoes.Size = new System.Drawing.Size(891, 408);
            this.tabAnotacoes.TabIndex = 3;
            this.tabAnotacoes.Text = "Salvos";
            this.tabAnotacoes.UseVisualStyleBackColor = true;
            // 
            // pnlAnotacoes
            // 
            this.pnlAnotacoes.BackColor = System.Drawing.Color.Transparent;
            this.pnlAnotacoes.Controls.Add(this.cmbCategoriaAnotacoes);
            this.pnlAnotacoes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAnotacoes.ForeColor = System.Drawing.SystemColors.GrayText;
            this.pnlAnotacoes.Location = new System.Drawing.Point(3, 3);
            this.pnlAnotacoes.Name = "pnlAnotacoes";
            this.pnlAnotacoes.Size = new System.Drawing.Size(885, 59);
            this.pnlAnotacoes.TabIndex = 8;
            // 
            // cmbCategoriaAnotacoes
            // 
            this.cmbCategoriaAnotacoes.AutoResize = false;
            this.cmbCategoriaAnotacoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbCategoriaAnotacoes.Depth = 0;
            this.cmbCategoriaAnotacoes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbCategoriaAnotacoes.DropDownHeight = 118;
            this.cmbCategoriaAnotacoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriaAnotacoes.DropDownWidth = 121;
            this.cmbCategoriaAnotacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbCategoriaAnotacoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbCategoriaAnotacoes.FormattingEnabled = true;
            this.cmbCategoriaAnotacoes.IntegralHeight = false;
            this.cmbCategoriaAnotacoes.ItemHeight = 29;
            this.cmbCategoriaAnotacoes.Items.AddRange(new object[] {
            "Anotações",
            "Versículos",
            "Grifos"});
            this.cmbCategoriaAnotacoes.Location = new System.Drawing.Point(14, 12);
            this.cmbCategoriaAnotacoes.MaxDropDownItems = 4;
            this.cmbCategoriaAnotacoes.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbCategoriaAnotacoes.Name = "cmbCategoriaAnotacoes";
            this.cmbCategoriaAnotacoes.Size = new System.Drawing.Size(253, 35);
            this.cmbCategoriaAnotacoes.StartIndex = 0;
            this.cmbCategoriaAnotacoes.TabIndex = 5;
            this.cmbCategoriaAnotacoes.UseTallSize = false;
            this.cmbCategoriaAnotacoes.SelectedIndexChanged += new System.EventHandler(this.cmbCategoriaAnotacoes_SelectedIndexChanged);
            // 
            // flowLayoutPanelAnotacoes
            // 
            this.flowLayoutPanelAnotacoes.AutoScroll = true;
            this.flowLayoutPanelAnotacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelAnotacoes.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelAnotacoes.Name = "flowLayoutPanelAnotacoes";
            this.flowLayoutPanelAnotacoes.Size = new System.Drawing.Size(885, 402);
            this.flowLayoutPanelAnotacoes.TabIndex = 0;
            // 
            // tabPlanoLeitura
            // 
            this.tabPlanoLeitura.Controls.Add(this.flowPanelPlanos);
            this.tabPlanoLeitura.Controls.Add(this.pnlCategoriaPlano);
            this.tabPlanoLeitura.ImageKey = "calendar-days.png";
            this.tabPlanoLeitura.Location = new System.Drawing.Point(4, 31);
            this.tabPlanoLeitura.Name = "tabPlanoLeitura";
            this.tabPlanoLeitura.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlanoLeitura.Size = new System.Drawing.Size(891, 408);
            this.tabPlanoLeitura.TabIndex = 5;
            this.tabPlanoLeitura.Text = "Plano de Leitura";
            this.tabPlanoLeitura.UseVisualStyleBackColor = true;
            // 
            // flowPanelPlanos
            // 
            this.flowPanelPlanos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelPlanos.Location = new System.Drawing.Point(3, 62);
            this.flowPanelPlanos.Name = "flowPanelPlanos";
            this.flowPanelPlanos.Size = new System.Drawing.Size(885, 343);
            this.flowPanelPlanos.TabIndex = 10;
            // 
            // pnlCategoriaPlano
            // 
            this.pnlCategoriaPlano.BackColor = System.Drawing.Color.Transparent;
            this.pnlCategoriaPlano.Controls.Add(this.cmbCategoriaPlanos);
            this.pnlCategoriaPlano.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCategoriaPlano.ForeColor = System.Drawing.SystemColors.GrayText;
            this.pnlCategoriaPlano.Location = new System.Drawing.Point(3, 3);
            this.pnlCategoriaPlano.Name = "pnlCategoriaPlano";
            this.pnlCategoriaPlano.Size = new System.Drawing.Size(885, 59);
            this.pnlCategoriaPlano.TabIndex = 9;
            // 
            // cmbCategoriaPlanos
            // 
            this.cmbCategoriaPlanos.AutoResize = false;
            this.cmbCategoriaPlanos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbCategoriaPlanos.Depth = 0;
            this.cmbCategoriaPlanos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbCategoriaPlanos.DropDownHeight = 118;
            this.cmbCategoriaPlanos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriaPlanos.DropDownWidth = 121;
            this.cmbCategoriaPlanos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbCategoriaPlanos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbCategoriaPlanos.FormattingEnabled = true;
            this.cmbCategoriaPlanos.IntegralHeight = false;
            this.cmbCategoriaPlanos.ItemHeight = 29;
            this.cmbCategoriaPlanos.Items.AddRange(new object[] {
            "Todos",
            "Meus",
            "\t\t\t"});
            this.cmbCategoriaPlanos.Location = new System.Drawing.Point(14, 12);
            this.cmbCategoriaPlanos.MaxDropDownItems = 4;
            this.cmbCategoriaPlanos.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbCategoriaPlanos.Name = "cmbCategoriaPlanos";
            this.cmbCategoriaPlanos.Size = new System.Drawing.Size(253, 35);
            this.cmbCategoriaPlanos.StartIndex = 0;
            this.cmbCategoriaPlanos.TabIndex = 5;
            this.cmbCategoriaPlanos.UseTallSize = false;
            this.cmbCategoriaPlanos.SelectedIndexChanged += new System.EventHandler(this.cmbCategoriaPlanos_SelectedIndexChanged);
            // 
            // tabBibleKids
            // 
            this.tabBibleKids.Controls.Add(this.pnlBibleKidPrincipal);
            this.tabBibleKids.Controls.Add(this.pnlBibleKids);
            this.tabBibleKids.ImageKey = "baby.png";
            this.tabBibleKids.Location = new System.Drawing.Point(4, 31);
            this.tabBibleKids.Name = "tabBibleKids";
            this.tabBibleKids.Padding = new System.Windows.Forms.Padding(3);
            this.tabBibleKids.Size = new System.Drawing.Size(891, 408);
            this.tabBibleKids.TabIndex = 4;
            this.tabBibleKids.Text = "Bíblia (crianças)";
            this.tabBibleKids.UseVisualStyleBackColor = true;
            // 
            // pnlBibleKidPrincipal
            // 
            this.pnlBibleKidPrincipal.Controls.Add(this.cardTextoHistoria);
            this.pnlBibleKidPrincipal.Controls.Add(this.pictureBoxImagemHistoria);
            this.pnlBibleKidPrincipal.ForeColor = System.Drawing.Color.White;
            this.pnlBibleKidPrincipal.Location = new System.Drawing.Point(3, 68);
            this.pnlBibleKidPrincipal.Name = "pnlBibleKidPrincipal";
            this.pnlBibleKidPrincipal.Size = new System.Drawing.Size(860, 321);
            this.pnlBibleKidPrincipal.TabIndex = 8;
            // 
            // cardTextoHistoria
            // 
            this.cardTextoHistoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardTextoHistoria.Depth = 0;
            this.cardTextoHistoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardTextoHistoria.Location = new System.Drawing.Point(30, 23);
            this.cardTextoHistoria.Margin = new System.Windows.Forms.Padding(14);
            this.cardTextoHistoria.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardTextoHistoria.Name = "cardTextoHistoria";
            this.cardTextoHistoria.Padding = new System.Windows.Forms.Padding(14);
            this.cardTextoHistoria.Size = new System.Drawing.Size(605, 287);
            this.cardTextoHistoria.TabIndex = 1;
            // 
            // pictureBoxImagemHistoria
            // 
            this.pictureBoxImagemHistoria.Location = new System.Drawing.Point(656, 48);
            this.pictureBoxImagemHistoria.Name = "pictureBoxImagemHistoria";
            this.pictureBoxImagemHistoria.Size = new System.Drawing.Size(160, 213);
            this.pictureBoxImagemHistoria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImagemHistoria.TabIndex = 0;
            this.pictureBoxImagemHistoria.TabStop = false;
            // 
            // pnlBibleKids
            // 
            this.pnlBibleKids.BackColor = System.Drawing.Color.Transparent;
            this.pnlBibleKids.Controls.Add(this.picBtnVoltarHistoria);
            this.pnlBibleKids.Controls.Add(this.picBtnProximaHistoria);
            this.pnlBibleKids.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBibleKids.ForeColor = System.Drawing.SystemColors.GrayText;
            this.pnlBibleKids.Location = new System.Drawing.Point(3, 3);
            this.pnlBibleKids.Name = "pnlBibleKids";
            this.pnlBibleKids.Size = new System.Drawing.Size(885, 59);
            this.pnlBibleKids.TabIndex = 7;
            // 
            // picBtnVoltarHistoria
            // 
            this.picBtnVoltarHistoria.Image = ((System.Drawing.Image)(resources.GetObject("picBtnVoltarHistoria.Image")));
            this.picBtnVoltarHistoria.Location = new System.Drawing.Point(30, 5);
            this.picBtnVoltarHistoria.Name = "picBtnVoltarHistoria";
            this.picBtnVoltarHistoria.Size = new System.Drawing.Size(77, 47);
            this.picBtnVoltarHistoria.TabIndex = 6;
            this.picBtnVoltarHistoria.TabStop = false;
            // 
            // picBtnProximaHistoria
            // 
            this.picBtnProximaHistoria.Image = ((System.Drawing.Image)(resources.GetObject("picBtnProximaHistoria.Image")));
            this.picBtnProximaHistoria.Location = new System.Drawing.Point(705, 5);
            this.picBtnProximaHistoria.Name = "picBtnProximaHistoria";
            this.picBtnProximaHistoria.Size = new System.Drawing.Size(77, 47);
            this.picBtnProximaHistoria.TabIndex = 5;
            this.picBtnProximaHistoria.TabStop = false;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.panelSettings);
            this.tabSettings.ImageKey = "settings.png";
            this.tabSettings.Location = new System.Drawing.Point(4, 31);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(891, 408);
            this.tabSettings.TabIndex = 6;
            this.tabSettings.Text = "Definições";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.gbSessao);
            this.panelSettings.Controls.Add(this.gbFonteTamanho);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettings.Location = new System.Drawing.Point(3, 3);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(885, 402);
            this.panelSettings.TabIndex = 0;
            // 
            // gbSessao
            // 
            this.gbSessao.Controls.Add(this.btnLogout);
            this.gbSessao.Controls.Add(this.SwitchManterSessao);
            this.gbSessao.Location = new System.Drawing.Point(15, 210);
            this.gbSessao.Name = "gbSessao";
            this.gbSessao.Size = new System.Drawing.Size(823, 136);
            this.gbSessao.TabIndex = 12;
            this.gbSessao.TabStop = false;
            this.gbSessao.Text = "Manter e Encerrar Sessão";
            // 
            // btnLogout
            // 
            this.btnLogout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogout.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogout.Depth = 0;
            this.btnLogout.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnLogout.HighEmphasis = true;
            this.btnLogout.Icon = null;
            this.btnLogout.Location = new System.Drawing.Point(18, 82);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogout.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLogout.Size = new System.Drawing.Size(78, 36);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogout.UseAccentColor = false;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // SwitchManterSessao
            // 
            this.SwitchManterSessao.AutoSize = true;
            this.SwitchManterSessao.Depth = 0;
            this.SwitchManterSessao.Location = new System.Drawing.Point(18, 31);
            this.SwitchManterSessao.Margin = new System.Windows.Forms.Padding(0);
            this.SwitchManterSessao.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SwitchManterSessao.MouseState = MaterialSkin.MouseState.HOVER;
            this.SwitchManterSessao.Name = "SwitchManterSessao";
            this.SwitchManterSessao.Ripple = true;
            this.SwitchManterSessao.Size = new System.Drawing.Size(144, 37);
            this.SwitchManterSessao.TabIndex = 2;
            this.SwitchManterSessao.Text = "Mudar tema";
            this.SwitchManterSessao.UseVisualStyleBackColor = true;
            // 
            // gbFonteTamanho
            // 
            this.gbFonteTamanho.Controls.Add(this.switchTema);
            this.gbFonteTamanho.Controls.Add(this.numericTamanho);
            this.gbFonteTamanho.Controls.Add(this.lblTamanho);
            this.gbFonteTamanho.Controls.Add(this.cmbFonte);
            this.gbFonteTamanho.Controls.Add(this.lblFonte);
            this.gbFonteTamanho.Location = new System.Drawing.Point(15, 15);
            this.gbFonteTamanho.Name = "gbFonteTamanho";
            this.gbFonteTamanho.Size = new System.Drawing.Size(823, 136);
            this.gbFonteTamanho.TabIndex = 0;
            this.gbFonteTamanho.TabStop = false;
            this.gbFonteTamanho.Text = "Tema e Fonte";
            // 
            // switchTema
            // 
            this.switchTema.AutoSize = true;
            this.switchTema.Depth = 0;
            this.switchTema.Location = new System.Drawing.Point(395, 31);
            this.switchTema.Margin = new System.Windows.Forms.Padding(0);
            this.switchTema.MouseLocation = new System.Drawing.Point(-1, -1);
            this.switchTema.MouseState = MaterialSkin.MouseState.HOVER;
            this.switchTema.Name = "switchTema";
            this.switchTema.Ripple = true;
            this.switchTema.Size = new System.Drawing.Size(144, 37);
            this.switchTema.TabIndex = 1;
            this.switchTema.Text = "Mudar tema";
            this.switchTema.UseVisualStyleBackColor = true;
            // 
            // numericTamanho
            // 
            this.numericTamanho.Location = new System.Drawing.Point(222, 77);
            this.numericTamanho.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericTamanho.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericTamanho.Name = "numericTamanho";
            this.numericTamanho.Size = new System.Drawing.Size(120, 22);
            this.numericTamanho.TabIndex = 4;
            this.numericTamanho.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // lblTamanho
            // 
            this.lblTamanho.AutoSize = true;
            this.lblTamanho.Depth = 0;
            this.lblTamanho.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTamanho.Location = new System.Drawing.Point(219, 31);
            this.lblTamanho.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTamanho.Name = "lblTamanho";
            this.lblTamanho.Size = new System.Drawing.Size(70, 19);
            this.lblTamanho.TabIndex = 3;
            this.lblTamanho.Text = "Tamanho";
            // 
            // cmbFonte
            // 
            this.cmbFonte.AutoResize = false;
            this.cmbFonte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbFonte.Depth = 0;
            this.cmbFonte.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbFonte.DropDownHeight = 118;
            this.cmbFonte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFonte.DropDownWidth = 121;
            this.cmbFonte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbFonte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbFonte.FormattingEnabled = true;
            this.cmbFonte.IntegralHeight = false;
            this.cmbFonte.ItemHeight = 29;
            this.cmbFonte.Items.AddRange(new object[] {
            "Segoe UI",
            "Arial",
            "Verdana",
            "Calibri"});
            this.cmbFonte.Location = new System.Drawing.Point(23, 64);
            this.cmbFonte.MaxDropDownItems = 4;
            this.cmbFonte.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbFonte.Name = "cmbFonte";
            this.cmbFonte.Size = new System.Drawing.Size(158, 35);
            this.cmbFonte.StartIndex = 0;
            this.cmbFonte.TabIndex = 2;
            this.cmbFonte.UseTallSize = false;
            // 
            // lblFonte
            // 
            this.lblFonte.AutoSize = true;
            this.lblFonte.Depth = 0;
            this.lblFonte.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFonte.Location = new System.Drawing.Point(20, 31);
            this.lblFonte.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFonte.Name = "lblFonte";
            this.lblFonte.Size = new System.Drawing.Size(45, 19);
            this.lblFonte.TabIndex = 0;
            this.lblFonte.Text = "Fonte:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "notepad-text.png");
            this.imageList1.Images.SetKeyName(1, "bot.png");
            this.imageList1.Images.SetKeyName(2, "book-marked(1).png");
            this.imageList1.Images.SetKeyName(3, "house.png");
            this.imageList1.Images.SetKeyName(4, "bookmark.png");
            this.imageList1.Images.SetKeyName(5, "baby.png");
            this.imageList1.Images.SetKeyName(6, "calendar-days.png");
            this.imageList1.Images.SetKeyName(7, "settings.png");
            this.imageList1.Images.SetKeyName(8, "bible.png");
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 510);
            this.Controls.Add(this.TabControlPrincipal);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.TabControlPrincipal;
            this.MinimumSize = new System.Drawing.Size(905, 510);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BeLight Bible";
            this.TabControlPrincipal.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.cardUltimaLeitura.ResumeLayout(false);
            this.cardUltimaLeitura.PerformLayout();
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
            this.tabAnotacoes.ResumeLayout(false);
            this.pnlAnotacoes.ResumeLayout(false);
            this.tabPlanoLeitura.ResumeLayout(false);
            this.pnlCategoriaPlano.ResumeLayout(false);
            this.tabBibleKids.ResumeLayout(false);
            this.pnlBibleKidPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagemHistoria)).EndInit();
            this.pnlBibleKids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBtnVoltarHistoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnProximaHistoria)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.gbSessao.ResumeLayout(false);
            this.gbSessao.PerformLayout();
            this.gbFonteTamanho.ResumeLayout(false);
            this.gbFonteTamanho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTamanho)).EndInit();
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
        private MaterialSkin.Controls.MaterialCard cardUltimaLeitura;
        private MaterialSkin.Controls.MaterialButton btnRetomarLeitura;
        private MaterialSkin.Controls.MaterialCard cardVersiculoDia;
        private MaterialSkin.Controls.MaterialButton btnCompartilharVersiculo;
        private MaterialSkin.Controls.MaterialButton btnSalvarVersiculo;
        private Label lblTextoVersiculo;
        private TabPage tabAnotacoes;
        private FlowLayoutPanel flowLayoutPanelAnotacoes;
        private TabPage tabBibleKids;
        private Panel pnlBibleKidPrincipal;
        private MaterialSkin.Controls.MaterialCard cardTextoHistoria;
        private PictureBox pictureBoxImagemHistoria;
        private Panel pnlBibleKids;
        private PictureBox picBtnVoltarHistoria;
        private PictureBox picBtnProximaHistoria;
        private Panel pnlAnotacoes;
        private MaterialSkin.Controls.MaterialComboBox cmbCategoriaAnotacoes;
        private TabPage tabPlanoLeitura;
        private FlowLayoutPanel flowPanelPlanos;
        private Panel pnlCategoriaPlano;
        private MaterialSkin.Controls.MaterialComboBox cmbCategoriaPlanos;
        private TabPage tabSettings;
        private Panel panelSettings;
        private GroupBox gbFonteTamanho;
        private MaterialSkin.Controls.MaterialLabel lblFonte;
        private MaterialSkin.Controls.MaterialComboBox cmbFonte;
        private MaterialSkin.Controls.MaterialLabel lblTamanho;
        private NumericUpDown numericTamanho;
        private MaterialSkin.Controls.MaterialSwitch switchTema;
        private GroupBox gbSessao;
        private MaterialSkin.Controls.MaterialSwitch SwitchManterSessao;
        private MaterialSkin.Controls.MaterialButton btnLogout;
    }
}