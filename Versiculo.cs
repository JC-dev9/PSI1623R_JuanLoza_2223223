using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeLightBible
{
    public class Versiculo
    {
        private Label lbl;

        public Versiculo(Label label)
        {
            lbl = label;
        }

        public void Grifar()
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    lbl.BackColor = colorDialog.Color;
                    // Aqui você pode salvar a cor no banco, se quiser
                }
            }
        }
        public void Salvar()
        {
            // Implementar lógica para salvar versículo
            MessageBox.Show("Versículo salvo!");
        }

        public void Anotar()
        {
            // Implementar lógica para anotar
            MessageBox.Show("Abrir anotação para o versículo.");
        }

        public void Copiar()
        {
            Clipboard.SetText(lbl.Text);
            MessageBox.Show("Versículo copiado para a área de transferência.");
        }

        public void AbrirChatbot()
        {
            // Abrir chatbot relacionado ao versículo
            MessageBox.Show("Abrindo Chatbot...");
        }

        public void Compartilhar()
        {
            // Implementar lógica para compartilhar
            MessageBox.Show("Abrindo opções de compartilhamento...");
        }
    }
}
