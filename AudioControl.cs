using System;
using System.Drawing;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace BeLightBible.Controls
{
    public class AudioControl : Panel
    {
        private PictureBox picAudio;
        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private FlowLayoutPanel flowLayoutParaLer;
        private bool isPlaying = false;
        private string textoAtual = "";

        public AudioControl(FlowLayoutPanel flowLayoutVersiculos)
        {
            this.flowLayoutParaLer = flowLayoutVersiculos;
            this.Size = new Size(40, 40); // Tamanho do painel ajustado

            // Ícone de áudio
            picAudio = new PictureBox
            {
                Image = Image.FromFile("volume-2.png"), // Ícone de "play"
                Size = new Size(32, 32),
                Location = new Point(4, 4),
                Cursor = Cursors.Hand,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            picAudio.Click += PicAudio_Click;

            this.Controls.Add(picAudio);
        }

        private void PicAudio_Click(object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                // Começa a leitura
                textoAtual = ObterTextoDosVersiculos();
                if (!string.IsNullOrWhiteSpace(textoAtual))
                {
                    synthesizer.SpeakCompleted += Synthesizer_SpeakCompleted;
                    synthesizer.SpeakAsyncCancelAll();
                    synthesizer.SpeakAsync(textoAtual);
                    picAudio.Image = Image.FromFile("pause.png"); // Atualize para seu ícone de "pause"
                    isPlaying = true;
                }
            }
            else
            {
                // Pausa (na prática: para a leitura)
                synthesizer.SpeakAsyncCancelAll();
                picAudio.Image = Image.FromFile("volume-2.png"); // Ícone de "play"
                isPlaying = false;
            }
        }

        private void Synthesizer_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            // Quando a leitura termina, resetar estado
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => picAudio.Image = Image.FromFile("volume-2.png")));
            }
            else
            {
                picAudio.Image = Image.FromFile("volume-2.png");
            }
            isPlaying = false;
        }

        private string ObterTextoDosVersiculos()
        {
            string texto = "";

            foreach (Control ctrl in flowLayoutParaLer.Controls)
            {
                if (ctrl is Panel card && card.Controls.Count > 0 && card.Controls[0] is Label lbl)
                {
                    texto += lbl.Text + " ";
                }
                else if (ctrl is Label lblDireto)
                {
                    texto += lblDireto.Text + " ";
                }
            }

            return texto.Trim();
        }
    }
}
