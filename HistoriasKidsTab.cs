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
        private Panel pnlBibleKids;
        private PictureBox pictureBoxExterno;
        private Panel pnlTextoComScroll;

        private PictureBox btnAnterior;
        private PictureBox btnProximo;
        private MaterialCard card;

        private List<HistoriaBiblica> historias;
        private int indiceAtual = 0;

        public HistoriasKidsTab(TabPage tabDestino, Panel pnlBibleKidPrincipal, PictureBox btnProximo, PictureBox btnAnterior, MaterialCard card, PictureBox pictureBoxExterno, Panel pnlBibleKids)
        {
            this.tab = tabDestino;
            this.pnlBibleKidPrincipal = pnlBibleKidPrincipal;
            this.card = card;

            this.btnProximo = btnProximo;
            this.btnAnterior = btnAnterior;
            this.pictureBoxExterno = pictureBoxExterno;
            this.pnlBibleKids = pnlBibleKids; // <-- novo

            InicializarHistorias();
            CriarComponentes();
            MostrarHistoriaAtual();
            CriarTituloPrincipal();

            this.btnProximo.Click += BtnProximo_Click;
            this.btnAnterior.Click += BtnAnterior_Click;
        }



        private Label lblTituloPrincipal;

        public void CriarTituloPrincipal()
        {
            lblTituloPrincipal = new Label
            {
                Text = "Bíblia para Crianças",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.Orange,
                BackColor = Color.Transparent,
                AutoSize = true
            };

            // Centraliza horizontalmente e posiciona um pouco abaixo do topo
            int centerX = (pnlBibleKidPrincipal.Width - lblTituloPrincipal.PreferredWidth) / 2 - 20; // <-- desloca 20px à esquerda
            lblTituloPrincipal.Location = new Point(centerX, 0); // Y no topo

            // Para garantir que ele se reposicione corretamente ao redimensionar o painel:


            pnlBibleKids.Controls.Add(lblTituloPrincipal);
        }

        public void InicializarHistorias()
        {
            historias = new List<HistoriaBiblica>
    {
        new HistoriaBiblica
        {
            Titulo = "Adão e Eva",
            Texto = "No começo, Deus criou o céu, a terra e tudo que existe. Ele fez o homem chamado Adão e a mulher chamada Eva, e os colocou em um jardim maravilhoso chamado Éden. Nesse jardim, havia árvores frutíferas, rios cristalinos, animais de todas as espécies, e um clima perfeito. Deus deu a eles a missão de cuidar do jardim e viver em harmonia com a natureza e com Ele. Adão e Eva eram felizes, tinham tudo o que precisavam e aprendiam sobre o amor e a bondade de Deus todos os dias. Mas Deus também deu a eles uma regra importante: não comer do fruto da árvore do conhecimento do bem e do mal. Essa história nos ensina sobre obediência, amor e como Deus quer que cuidemos da criação com responsabilidade e carinho.",
            CaminhoImagem = @"C:\Users\juanl\Source\Repos\PSI1623R_JuanLoza_2223223\Imagens\adaoEva.png"
        },
        new HistoriaBiblica
        {
            Titulo = "Noé e a Arca",
            Texto = "Deus viu que o mundo estava cheio de maldade e decidiu limpá-lo com um grande dilúvio. Mas Noé era um homem justo. Deus pediu a Noé para construir uma arca bem grande para salvar sua família e os animais. Noé obedeceu. Quando a chuva veio, ele entrou na arca com sua família e dois animais de cada espécie. Depois de muitos dias, a chuva parou e a arca parou em terra firme. Deus colocou um arco-íris no céu como sinal de Sua promessa de nunca mais destruir a Terra com água.",
            CaminhoImagem = @"C:\Users\juanl\Source\Repos\PSI1623R_JuanLoza_2223223\Imagens\noe.png"
        },
        new HistoriaBiblica
        {
            Titulo = "Moisés e o Mar Vermelho",
            Texto = "Moisés foi escolhido por Deus para libertar o povo de Israel da escravidão no Egito. Depois de muitos sinais e milagres, o faraó deixou o povo ir. Mas depois mudou de ideia e mandou soldados atrás deles. Deus abriu o Mar Vermelho para que os israelitas passassem a pé enxuto. Quando os egípcios tentaram seguir, o mar se fechou. Deus salvou seu povo com grande poder.",
            CaminhoImagem = @"C:\caminho\moises.png"
        },
        new HistoriaBiblica
        {
            Titulo = "Davi e Golias",
            Texto = "Davi era um jovem pastor. Um dia, ele ouviu falar de um gigante chamado Golias que desafiava o povo de Deus. Davi confiou em Deus e decidiu enfrentá-lo. Com apenas uma pedra e uma funda, ele derrotou o gigante. Essa história mostra que com fé, coragem e confiança em Deus, podemos vencer qualquer dificuldade.",
            CaminhoImagem = @"C:\caminho\davi.png"
        },
        new HistoriaBiblica
        {
            Titulo = "Daniel na Cova dos Leões",
            Texto = "Daniel era fiel a Deus, mesmo quando foi proibido de orar. Por causa disso, ele foi jogado numa cova cheia de leões. Mas Deus enviou um anjo que fechou a boca dos leões, e Daniel saiu ileso. Essa história mostra que Deus protege os que são fiéis a Ele.",
            CaminhoImagem = @"C:\caminho\daniel.png"
        },
        new HistoriaBiblica
        {
            Titulo = "Jonas e o Grande Peixe",
            Texto = "Jonas tentou fugir de uma missão de Deus e acabou sendo engolido por um grande peixe. Dentro do peixe, ele orou e se arrependeu. Depois de três dias, o peixe o vomitou em terra firme. Jonas então obedeceu e levou a mensagem de Deus à cidade de Nínive. A história mostra a importância da obediência e do arrependimento.",
            CaminhoImagem = @"C:\caminho\jonas.png"
        },
        new HistoriaBiblica
        {
            Titulo = "O Nascimento de Jesus",
            Texto = "Jesus nasceu em Belém, em um estábulo, pois não havia lugar na hospedaria. Um anjo contou aos pastores que o Salvador havia nascido. Os magos do oriente também vieram adorá-lo, guiados por uma estrela. O nascimento de Jesus é o presente mais especial de Deus para o mundo.",
            CaminhoImagem = @"C:\caminho\jesus_nasceu.png"
        },
        new HistoriaBiblica
        {
            Titulo = "Jesus Acalma a Tempestade",
            Texto = "Jesus e seus discípulos estavam em um barco quando uma grande tempestade começou. Os discípulos ficaram com medo, mas Jesus, com calma, disse ao vento e às ondas: 'Aquietem-se!' E tudo se acalmou. Essa história nos lembra que Jesus está conosco mesmo nas tempestades da vida.",
            CaminhoImagem = @"C:\caminho\tempestade.png"
        }
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
