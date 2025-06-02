using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public static (string Livro, int Capitulo)? ObterUltimoPonto(int userId)
        {
            using (var context = new Entities())
            {
                var ultimo = context.UltimoPontoLeitura.SingleOrDefault(x => x.UserId == userId);
                if (ultimo != null)
                {
                    return (ultimo.Livro, ultimo.Capitulo);
                }
                return null;
            }
        }

        public static void SalvarUltimoPonto(int userId, string livro, int capitulo)
        {
            using (var context = new Entities())
            {
                var ultimo = context.UltimoPontoLeitura.SingleOrDefault(x => x.UserId == userId);

                if (ultimo != null)
                {
                    ultimo.Livro = livro;
                    ultimo.Capitulo = capitulo;
                    ultimo.DataAtualizacao = DateTime.Now;
                }
                else
                {
                    context.UltimoPontoLeitura.Add(new UltimoPontoLeitura
                    {
                        UserId = userId,
                        Livro = livro,
                        Capitulo = capitulo,
                        DataAtualizacao = DateTime.Now
                    });
                }

                context.SaveChanges();
            }
        }


        public void SalvarVersiculoEF(int userId, string referencia, string texto)
        {
            try
            {
                // Exemplo: "Salmos 37:5"
                string[] partes = referencia.Split(' ');
                string livro = partes[0];
                string[] capVers = partes[1].Split(':');
                int capitulo = int.Parse(capVers[0]);
                int versiculo = int.Parse(capVers[1]);

                using (var context = new Entities()) // Substitua pelo nome do seu DbContext
                {
                    bool jaExiste = context.VersiculoSalvo.Any(v =>
                        v.UserId == userId &&
                        v.Livro == livro &&
                        v.Capitulo == capitulo &&
                        v.Versiculo == versiculo
                    );

                    if (!jaExiste)
                    {
                        var versiculoSalvo = new VersiculoSalvo
                        {
                            UserId = userId,
                            Livro = livro,
                            Capitulo = capitulo,
                            Versiculo = versiculo,
                            Texto = texto,
                            DataSalvo = DateTime.Now
                        };

                        context.VersiculoSalvo.Add(versiculoSalvo);
                        context.SaveChanges();
                        MessageBox.Show("Versículo salvo com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Versículo já salvo anteriormente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o versículo: " + ex.Message);
            }
        }


        private void SalvarGrifo(int userId, string livro, int capitulo, int versiculo, string corHex)
        {
            using (var context = new Entities())
            {
                var grifoExistente = context.VersiculoSublinhado.FirstOrDefault(v => v.UserId == userId && v.Livro == livro && v.Capitulo == capitulo && v.Versiculo == versiculo);

                if (grifoExistente != null)
                {
                    grifoExistente.Cor = corHex;
                }
                else
                {
                    var novoGrifo = new VersiculoSublinhado
                    {
                        UserId = userId,
                        Livro = livro,
                        Capitulo = capitulo,
                        Versiculo = versiculo,
                        Cor = corHex
                    };

                    context.VersiculoSublinhado.Add(novoGrifo);
                }

                context.SaveChanges();
            }
        }


        public void Grifar(int userId, string livro, int capitulo, int versiculo)
        {

            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Atualiza a cor de fundo do Label
                    lbl.BackColor = colorDialog.Color;

                    // Converte a cor selecionada para o formato hexadecimal
                    string corHex = ColorTranslator.ToHtml(colorDialog.Color);

                    try
                    {
                        // Salva a cor no banco de dados
                        SalvarGrifo(userId, livro, capitulo, versiculo, corHex);
                        MessageBox.Show("Grifo salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Trata possíveis erros ao salvar no banco de dados
                        MessageBox.Show($"Erro ao salvar o grifo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public void Salvar()
        {
            // Implementar lógica para salvar versículo
            MessageBox.Show("Versículo salvo!");
        }

        public async Task Anotar(int userId, string livro, int capitulo, int versiculo, Func<Task> recarregarCallback)
        {
            using (var context = new Entities())
            {
                var anotacaoExistente = context.VersiculoAnotado
                    .FirstOrDefault(v => v.UserId == userId && v.Livro == livro && v.Capitulo == capitulo && v.Versiculo == versiculo);

                string textoAtual = anotacaoExistente?.Texto ?? "";

                using (FormAnotacao form = new FormAnotacao(textoAtual))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (anotacaoExistente != null)
                        {
                            anotacaoExistente.Texto = form.TextoAnotacao;
                        }
                        else
                        {
                            context.VersiculoAnotado.Add(new VersiculoAnotado
                            {
                                UserId = userId,
                                Livro = livro,
                                Capitulo = capitulo,
                                Versiculo = versiculo,
                                Texto = form.TextoAnotacao
                            });
                        }

                        context.SaveChanges();
                    }

                    // Chama o callback pra recarregar a interface
                    if (recarregarCallback != null)
                    {
                        await recarregarCallback();
                    }
                }
            }
        }
        public void Copiar()
        {
            Clipboard.SetText(lbl.Text);
            MessageBox.Show("Versículo copiado para a área de transferência.");
        }

        public void Explicar(string livro, int capitulo, int versiculo, TabPage tabChatbot, TabControl tabControl, Action<string> exibirMensagem, Func<string, Task> enviarPrompt)
        {

        }


        public void Compartilhar()
        {
            // Implementar lógica para compartilhar
            MessageBox.Show("Abrindo opções de compartilhamento...");
        }
    }
}
