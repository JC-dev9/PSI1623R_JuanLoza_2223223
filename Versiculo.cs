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
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.IO.Image;
using iText.IO.Font;
using iText.Kernel.Font;
using System.IO;

namespace BeLightBible
{
    public class Versiculo
    {
        private Label lbl;

        public Versiculo(Label label)
        {
            lbl = label;
        }

        // Retorna lista de versículos salvos por usuário, ordenados pela data
        public static List<VersiculoSalvo> ObterVersiculosSalvos(int userId)
        {
            using (var context = new Entities())
            {
                return context.VersiculoSalvo
                    .Where(v => v.UserId == userId)
                    .OrderByDescending(v => v.DataSalvo)
                    .ToList();
            }
        }

        // Remove versículo salvo do usuário
        public static void ExcluirVersiculoSalvo(int userId, string livro, int capitulo, int versiculo)
        {
            using (var context = new Entities())
            {
                var versiculoSalvo = context.VersiculoSalvo.FirstOrDefault(v =>
                    v.UserId == userId &&
                    v.Livro == livro &&
                    v.Capitulo == capitulo &&
                    v.Versiculo == versiculo);

                if (versiculoSalvo != null)
                {
                    context.VersiculoSalvo.Remove(versiculoSalvo);
                    context.SaveChanges();
                }
            }
        }

        // Obtém o último ponto de leitura do usuário
        public static (string Livro, int Capitulo)? ObterUltimoPonto(int userId)
        {
            using (var context = new Entities())
            {
                var ultimo = context.UltimoPontoLeitura.SingleOrDefault(x => x.UserId == userId);
                if (ultimo != null)
                    return (ultimo.Livro, ultimo.Capitulo);

                return null;
            }
        }

        // Salva ou atualiza o último ponto de leitura
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

        // Salva um novo versículo favorito
        public void SalvarVersiculoEF(int userId, string referencia, string texto)
        {
            try
            {
                string[] partes = referencia.Split(' ');
                string capVersStr = partes.Last();
                string livro = string.Join(" ", partes.Take(partes.Length - 1));

                string[] capVers = capVersStr.Split(':');
                int capitulo = int.Parse(capVers[0]);
                int versiculo = int.Parse(capVers[1]);

                using (var context = new Entities())
                {
                    bool jaExiste = context.VersiculoSalvo.Any(v =>
                        v.UserId == userId &&
                        v.Livro == livro &&
                        v.Capitulo == capitulo &&
                        v.Versiculo == versiculo);

                    if (!jaExiste)
                    {
                        context.VersiculoSalvo.Add(new VersiculoSalvo
                        {
                            UserId = userId,
                            Livro = livro,
                            Capitulo = capitulo,
                            Versiculo = versiculo,
                            Texto = texto,
                            DataSalvo = DateTime.Now
                        });

                        context.SaveChanges();
                        MessageBox.Show("Versículo salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Versículo já salvo anteriormente.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o versículo: " + ex.Message);
            }
        }

        // Retorna grifos de um capítulo
        public static List<VersiculoSublinhado> ObterGrifosUtilizador(int userId, string livro, int capitulo)
        {
            using (var context = new Entities())
            {
                return context.VersiculoSublinhado
                    .Where(v => v.UserId == userId && v.Livro == livro && v.Capitulo == capitulo)
                    .ToList();
            }
        }

        // Retorna todos os grifos do usuário
        public static List<VersiculoSublinhado> ObterGrifosUtilizador(int userId)
        {
            using (var context = new Entities())
            {
                return context.VersiculoSublinhado
                    .Where(v => v.UserId == userId)
                    .ToList();
            }
        }

        // Exclui grifo
        public static void ExcluirGrifo(int userId, string livro, int capitulo, int versiculo)
        {
            using (var context = new Entities())
            {
                var grifo = context.VersiculoSublinhado.FirstOrDefault(v =>
                    v.UserId == userId &&
                    v.Livro == livro &&
                    v.Capitulo == capitulo &&
                    v.Versiculo == versiculo);

                if (grifo != null)
                {
                    context.VersiculoSublinhado.Remove(grifo);
                    context.SaveChanges();
                }
            }
        }

        // Salva ou atualiza um grifo
        private void SalvarGrifo(int userId, string livro, int capitulo, int versiculo, string texto, string corHex)
        {
            using (var context = new Entities())
            {
                var grifoExistente = context.VersiculoSublinhado.FirstOrDefault(v =>
                    v.UserId == userId && v.Livro == livro &&
                    v.Capitulo == capitulo && v.Versiculo == versiculo);

                if (grifoExistente != null)
                {
                    grifoExistente.Cor = corHex;
                }
                else
                {
                    context.VersiculoSublinhado.Add(new VersiculoSublinhado
                    {
                        UserId = userId,
                        Livro = livro,
                        Capitulo = capitulo,
                        Versiculo = versiculo,
                        Texto = texto,
                        Cor = corHex,
                        DataCriado = DateTime.Now
                    });
                }

                context.SaveChanges();
            }
        }

        // Mostra seletor de cor e salva grifo no banco
        public void Grifar(int userId, string livro, int capitulo, int versiculo, string texto)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    lbl.BackColor = colorDialog.Color;
                    string corHex = ColorTranslator.ToHtml(colorDialog.Color);

                    try
                    {
                        SalvarGrifo(userId, livro, capitulo, versiculo, texto, corHex);
                        MessageBox.Show("Grifo salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar o grifo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Retorna anotações do usuário
        public static List<VersiculoAnotado> ObterAnotacoes(int userId)
        {
            using (var context = new Entities())
            {
                return context.VersiculoAnotado
                    .Where(v => v.UserId == userId)
                    .OrderByDescending(v => v.DataSalvo)
                    .ToList();
            }
        }

        // Abre formulário de anotação e salva no banco
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
                                Texto = form.TextoAnotacao,
                                DataSalvo = DateTime.Now
                            });
                        }

                        context.SaveChanges();
                    }

                    if (recarregarCallback != null)
                        await recarregarCallback();
                }
            }
        }

        // Copia o conteúdo do label para a área de transferência
        public void Copiar()
        {
            Clipboard.SetText(lbl.Text);
            MessageBox.Show("Versículo copiado para a área de transferência.");
        }

        // (A ser implementado) Lógica de compartilhamento
        public void Compartilhar()
        {
            MessageBox.Show("Abrindo opções de compartilhamento...");
        }
    }
}
