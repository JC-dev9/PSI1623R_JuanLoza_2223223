using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeLightBible
{
    public partial class HomeTab : UserControl
    {

        public HomeTab()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            // Versículo do Dia
            var versiculoTitulo = new MaterialLabel
            {
                Text = "Versículo do Dia",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(30, 30),
                AutoSize = true
            };
            Controls.Add(versiculoTitulo);

            var versiculoTexto = new MaterialLabel
            {
                Text = "Lâmpada para os meus pés é a tua palavra e,\nluz para o meu caminho.\nSalmo 119:105",
                Font = new Font("Segoe UI", 12),
                Location = new Point(30, 70),
                AutoSize = true
            };
            Controls.Add(versiculoTexto);

            var btnSalvar = new MaterialButton
            {
                Text = "Salvar",
                Location = new Point(30, 150)
            };
            Controls.Add(btnSalvar);

            var btnCompartilhar = new MaterialButton
            {
                Text = "Compartilhar",
                Location = new Point(130, 150)
            };
            Controls.Add(btnCompartilhar);

            // Progresso da Leitura Bíblica
            var lblProgresso = new MaterialLabel
            {
                Text = "Progresso de Leitura Bíblica",
                Location = new Point(400, 30),
                AutoSize = true
            };
            Controls.Add(lblProgresso);

            var progressBar = new ProgressBar
            {
                Value = 32,
                Location = new Point(400, 60),
                Size = new Size(200, 10)
            };
            Controls.Add(progressBar);

            var btnContinuar = new MaterialButton
            {
                Text = "Continuar",
                Location = new Point(400, 80)
            };
            Controls.Add(btnContinuar);

            // Devocional Diário
            var lblDevocional = new MaterialLabel
            {
                Text = "Devocional Diário\nPequeno texto com pensamento ou citação espiritual.",
                Location = new Point(400, 130),
                Size = new Size(250, 50)
            };
            Controls.Add(lblDevocional);

            var btnLerMais = new MaterialButton
            {
                Text = "Ler Mais",
                Location = new Point(400, 190)
            };
            Controls.Add(btnLerMais);

            // Última Leitura
            var lblUltimaLeitura = new MaterialLabel
            {
                Text = "Última Leitura: João 3:16",
                Location = new Point(400, 240),
                AutoSize = true
            };
            Controls.Add(lblUltimaLeitura);

            var btnRetomar = new MaterialButton
            {
                Text = "Retomar",
                Location = new Point(400, 270)
            };
            Controls.Add(btnRetomar);
        }
    }
}

