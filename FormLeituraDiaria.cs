using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BeLightBible
{
    public partial class FormLeituraDiaria : MaterialForm
    {
        private int planoUtilizadorId;
        private int diaAtual;
        private int diasTotais;

        private Label lblTitulo;
        private ProgressBar progressBar;
        private FlowLayoutPanel flowCapitulos;
        private MaterialButton btnConcluirDia;

        public FormLeituraDiaria(int planoUtilizadorId)
        {
            this.planoUtilizadorId = planoUtilizadorId;

            // Skin
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey500,
                Primary.BlueGrey700,
                Primary.BlueGrey100,
                Accent.Orange400,
                TextShade.WHITE
            );

            this.Text = "Leitura Diária";
            this.Size = new Size(600, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            CriarControles();
            CarregarLeituraDoDia();
        }

        private void CriarControles()
        {
            lblTitulo = new Label
            {
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 80)
            };
            this.Controls.Add(lblTitulo);

            progressBar = new ProgressBar
            {
                Location = new Point(20, 120),
                Width = this.ClientSize.Width - 40,
                Height = 25
            };
            this.Controls.Add(progressBar);

            flowCapitulos = new FlowLayoutPanel
            {
                Location = new Point(20, 160),
                Size = new Size(this.ClientSize.Width - 40, 300),
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };
            this.Controls.Add(flowCapitulos);

            btnConcluirDia = new MaterialButton
            {
                Text = "Concluir Dia",
                Size = new Size(150, 40),
                Location = new Point(20, 480)
            };
            btnConcluirDia.Click += btnConcluirDia_Click;
            this.Controls.Add(btnConcluirDia);
        }

        private void CarregarLeituraDoDia()
        {
            using (var db = new Entities())
            {
                var planoUser = db.PlanoLeituraUtilizador.FirstOrDefault(p => p.Id == planoUtilizadorId);
                if (planoUser == null)
                {
                    MessageBox.Show("Plano não encontrado.");
                    this.Close();
                    return;
                }

                diaAtual = (int)planoUser.ProgressoDiaAtual;
                diasTotais = db.PlanoLeituraModeloDia
                               .Where(p => p.PlanoLeituraId == planoUser.PlanoLeituraId)
                               .Select(p => p.Dia)
                               .DefaultIfEmpty(0)
                               .Max();

                lblTitulo.Text = $"Dia {diaAtual} de {diasTotais}";
                progressBar.Value = Math.Min(100, (int)((float)diaAtual / diasTotais * 100));

                var leituraDia = db.PlanoLeituraDia
                                   .FirstOrDefault(d => d.PlanoUtilizadorId == planoUtilizadorId && d.Dia == diaAtual);

                // Se ainda não tiver instância de leitura gerada, gerar com base no modelo
                if (leituraDia == null)
                {
                    var modelo = db.PlanoLeituraModeloDia
                                   .FirstOrDefault(m => m.PlanoLeituraId == planoUser.PlanoLeituraId && m.Dia == diaAtual);

                    if (modelo != null)
                    {
                        leituraDia = new PlanoLeituraDia
                        {
                            PlanoUtilizadorId = planoUtilizadorId,
                            Dia = diaAtual,
                            Capitulos = modelo.Capitulos,
                            Lido = false
                        };

                        db.PlanoLeituraDia.Add(leituraDia);
                        db.SaveChanges();
                    }
                }

                // Mostrar capítulos
                flowCapitulos.Controls.Clear();

                if (leituraDia != null && !string.IsNullOrWhiteSpace(leituraDia.Capitulos))
                {
                    var capitulos = leituraDia.Capitulos.Split(',');

                    foreach (var cap in capitulos)
                    {
                        var check = new CheckBox
                        {
                            Text = cap.Trim(),
                            AutoSize = true,
                            ForeColor = Color.White,
                            Font = new Font("Segoe UI", 12),
                            Margin = new Padding(5)
                        };
                        flowCapitulos.Controls.Add(check);
                    }
                }
                else
                {
                    MessageBox.Show("Nenhuma leitura encontrada para hoje.");
                }
            }
        }

        private void btnConcluirDia_Click(object sender, EventArgs e)
        {
            using (var db = new Entities())
            {
                var leitura = db.PlanoLeituraDia
                                .FirstOrDefault(d => d.PlanoUtilizadorId == planoUtilizadorId && d.Dia == diaAtual);

                if (leitura != null && leitura.Lido == false)
                {
                    leitura.Lido = true;
                    leitura.DataLeitura = DateTime.Now;
                }

                var planoUser = db.PlanoLeituraUtilizador.FirstOrDefault(p => p.Id == planoUtilizadorId);

                if (planoUser != null)
                {
                    if (planoUser.ProgressoDiaAtual < diasTotais)
                    {
                        planoUser.ProgressoDiaAtual++;
                        db.SaveChanges();
                        CarregarLeituraDoDia();
                    }
                    else
                    {
                        db.SaveChanges();
                        MessageBox.Show("Parabéns! Você concluiu o plano de leitura.");
                        this.Close();
                    }
                }
            }
        }
    }
}
