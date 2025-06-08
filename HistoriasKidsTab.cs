using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeLightBible
{
    public class HistoriaBiblica
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string CaminhoImagem { get; set; }
    }

    public class HistoriasKidsTab
    {
        private TabPage tab;
        private Label lblTitulo;
        private Label lblTexto;

        private Panel pnlBibleKidPrincipal;
        private PictureBox pictureBoxExterno;
        private Panel pnlTextoComScroll;

        private PictureBox pictureBox;
        private PictureBox btnAnterior;
        private PictureBox btnProximo;
        private MaterialCard card;

        private List<HistoriaBiblica> historias;
        private int indiceAtual = 0;

        public HistoriasKidsTab(TabPage tabDestino, Panel pnlBibleKidPrincipal, PictureBox btnProximo, PictureBox btnAnterior, MaterialCard card, PictureBox pictureBoxExterno)
        {
            this.tab = tabDestino;
            this.pnlBibleKidPrincipal = pnlBibleKidPrincipal;
            this.card = card;

            this.btnProximo = btnProximo;
            this.btnAnterior = btnAnterior;
            this.pictureBoxExterno = pictureBoxExterno;

            InicializarHistorias();
            CriarComponentes();
            MostrarHistoriaAtual();

            this.btnProximo.Click += BtnProximo_Click;
            this.btnAnterior.Click += BtnAnterior_Click;
        }


        private void InicializarHistorias()
        {
            historias = new List<HistoriaBiblica>
            {
            new HistoriaBiblica
            {
                Titulo = "Adão e Eva",
                  Texto = "No começo, Deus criou o céu, a terra e tudo que existe. Ele fez o homem chamado Adão e a mulher chamada Eva, e os colocou em um jardim maravilhoso chamado Éden. Nesse jardim, havia árvores frutíferas, rios cristalinos, animais de todas as espécies, e um clima perfeito. Deus deu a eles a missão de cuidar do jardim e viver em harmonia com a natureza e com Ele. Adão e Eva eram felizes, tinham tudo o que precisavam e aprendiam sobre o amor e a bondade de Deus todos os dias. Mas Deus também deu a eles uma regra importante: não comer do fruto da árvore do conhecimento do bem e do mal. Essa história nos ensina sobre obediência, amor e como Deus quer que cuidemos da criação com responsabilidade e carinho.",
                CaminhoImagem = @"C:\Users\juanl\OneDrive - Escola Digital\BeLightBible - C#\BeLightBible\Imagens\adaoEva.png"

            },
            new HistoriaBiblica
            {
                Titulo = "Noé e a Arca",
                Texto = "Noé construiu uma arca para salvar sua família e os animais.",
            },
            // + mais histórias se quiser
        };
        }
        public void CriarComponentes()
        {
            card.Controls.Clear();

            lblTitulo = new Label
            {
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Margin = new Padding(1),
                Padding = new Padding(1),
                Location = new Point(10, 10)
            };

            pnlTextoComScroll = new Panel
            {
                Location = new Point(10, 50),  // abaixo do título
                Size = new Size(card.Width - 20, card.Height - 60),  // ajuste tamanho para caber no card
                AutoScroll = true,
                BackColor = Color.Transparent
            };

            lblTexto = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(pnlTextoComScroll.Width - 20, 0),  // limita largura para quebrar linhas
                Font = new Font("Segoe UI", 12, FontStyle.Italic),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Location = new Point(0, 0),
                Padding = new Padding(2)
            };

            pnlTextoComScroll.Controls.Add(lblTexto);
            card.Controls.Add(lblTitulo);
            card.Controls.Add(pnlTextoComScroll);
        }


        private void MostrarHistoriaAtual()
        {
            if (historias.Count == 0) return;

            var historia = historias[indiceAtual];
            lblTitulo.Text = historia.Titulo;
            lblTexto.Text = historia.Texto;

            if (!string.IsNullOrEmpty(historia.CaminhoImagem) && System.IO.File.Exists(historia.CaminhoImagem))
            {
                pictureBoxExterno.Image?.Dispose();
                pictureBoxExterno.Image = Image.FromFile(historia.CaminhoImagem);
            }
            else
            {
                pictureBoxExterno.Image = null;
            }
        }




        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (indiceAtual > 0)
            {
                indiceAtual--;
                MostrarHistoriaAtual();
            }
        }

        private void BtnProximo_Click(object sender, EventArgs e)
        {
            if (indiceAtual < historias.Count - 1)
            {
                indiceAtual++;
                MostrarHistoriaAtual();
            }
        }
    }

}
