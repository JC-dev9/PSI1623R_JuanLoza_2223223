using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeLightBible
{
    public class Estilo
    {

        public void EstilizarPictureBoxComoBotao(PictureBox pic, bool proximo, ComboBox cmbLivro, ComboBox cmbCapitulo, Func<string, int, Task> BibleTab)
        {
            pic.BackColor = Color.FromArgb(255, 112, 67); // DeepOrange200
            pic.SizeMode = PictureBoxSizeMode.CenterImage;
            pic.Cursor = Cursors.Hand;
            pic.Padding = new Padding(8);

            // EVENTOS VISUAIS (sem problema em acumular)
            pic.MouseEnter += (s, e) => pic.BackColor = Color.FromArgb(255, 138, 101);  // DeepOrange300
            pic.MouseDown += (s, e) => pic.BackColor = Color.FromArgb(230, 74, 25);    // DeepOrange700
            pic.MouseUp += (s, e) => pic.BackColor = Color.FromArgb(255, 138, 101);
            pic.MouseLeave += (s, e) => pic.BackColor = Color.FromArgb(255, 112, 67);  // Voltar para DeepOrange200

            // REMOVER EVENTOS DE CLICK ANTERIORES
            if (pic.Tag is EventHandler handlerAntigo)
                pic.Click -= handlerAntigo;

            // CRIAR E ARMAZENAR NOVO HANDLER
            EventHandler handlerNovo = async (s, e) =>
            {
                if (cmbCapitulo.Items.Count == 0)
                {
                    MessageBox.Show("Selecione um livro primeiro.");
                    return;
                }

                if (proximo)
                {
                    if (cmbCapitulo.SelectedIndex < cmbCapitulo.Items.Count - 1)
                    {
                        cmbCapitulo.SelectedIndex += 1;
                        await BibleTab(cmbLivro.SelectedItem.ToString(), cmbCapitulo.SelectedIndex + 1);
                    }
                    else
                    {
                        MessageBox.Show("Você já está no último capítulo.");
                    }
                }
                else
                {
                    if (cmbCapitulo.SelectedIndex > 0)
                    {
                        cmbCapitulo.SelectedIndex -= 1;
                        await BibleTab(cmbLivro.SelectedItem.ToString(), cmbCapitulo.SelectedIndex + 1);
                    }
                    else
                    {
                        MessageBox.Show("Você já está no primeiro capítulo.");
                    }
                }
            };

            pic.Click += handlerNovo;
            pic.Tag = handlerNovo; // Guardar referência para remover depois, se necessário
        }

        public void EstilizarPictureBoxAudio(PictureBox pic)
        {
            pic.BackColor = Color.FromArgb(255, 112, 67); // DeepOrange200
            pic.SizeMode = PictureBoxSizeMode.CenterImage;
            pic.Cursor = Cursors.Hand;
            pic.Padding = new Padding(8);

            pic.MouseEnter += (s, e) => pic.BackColor = Color.FromArgb(255, 138, 101);  // DeepOrange300
            pic.MouseDown += (s, e) => pic.BackColor = Color.FromArgb(230, 74, 25);    // DeepOrange700
            pic.MouseUp += (s, e) => pic.BackColor = Color.FromArgb(255, 138, 101);
            pic.MouseLeave += (s, e) => pic.BackColor = Color.FromArgb(255, 112, 67);  // Voltar para DeepOrange200
        }

        public void EstilizarPictureBoxComoBotao(PictureBox pic)
        {
            pic.BackColor = Color.FromArgb(255, 112, 67); // DeepOrange200
            pic.SizeMode = PictureBoxSizeMode.CenterImage;
            pic.Cursor = Cursors.Hand;
            pic.Padding = new Padding(8);

            pic.MouseEnter += (s, e) => pic.BackColor = Color.FromArgb(255, 138, 101);  // DeepOrange300
            pic.MouseDown += (s, e) => pic.BackColor = Color.FromArgb(230, 74, 25);    // DeepOrange700
            pic.MouseUp += (s, e) => pic.BackColor = Color.FromArgb(255, 138, 101);
            pic.MouseLeave += (s, e) => pic.BackColor = Color.FromArgb(255, 112, 67);  // Voltar para DeepOrange200
        }

        public void ArredondarControle(Control controle, int raio)
        {
            var path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, raio, raio), 180, 90);
            path.AddArc(new Rectangle(controle.Width - raio, 0, raio, raio), 270, 90);
            path.AddArc(new Rectangle(controle.Width - raio, controle.Height - raio, raio, raio), 0, 90);
            path.AddArc(new Rectangle(0, controle.Height - raio, raio, raio), 90, 90);
            path.CloseFigure();

            controle.Region = new Region(path);
        }

    }
}
