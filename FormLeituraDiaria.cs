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

        public event EventHandler ProgressoAtualizado;


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
                Accent.DeepOrange200,
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

                // A barra inicia com o progresso correto
                int progressoDia = diaAtual - 1;
                if (progressoDia < 0) progressoDia = 0;

                progressBar.Value = Math.Min(100, (int)((float)progressoDia / diasTotais * 100));


                var leituraDia = db.PlanoLeituraDia
                                   .FirstOrDefault(d => d.PlanoUtilizadorId == planoUtilizadorId && d.Dia == diaAtual);

                if (leituraDia == null)
                {
                    var modelo = db.PlanoLeituraModeloDia
                                   .Where(m => m.PlanoLeituraId == planoUser.PlanoLeituraId && m.Dia == diaAtual)
                                   .FirstOrDefault();

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

                        check.CheckedChanged += Check_CheckedChanged; // adicionar evento

                        flowCapitulos.Controls.Add(check);
                    }

                    // Atualiza estado do botão Concluir Dia conforme os checkboxes carregados
                    AtualizarEstadoBotaoConcluir();
                }
                else
                {
                    MessageBox.Show("Nenhuma leitura encontrada para hoje.");
                    btnConcluirDia.Enabled = false; // desabilitar se nada para ler
                }
            }
        }

        private void Check_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarEstadoBotaoConcluir();
        }

        private void AtualizarEstadoBotaoConcluir()
        {
            // O botão só habilita se todos os checkboxes estiverem marcados
            bool todosMarcados = flowCapitulos.Controls
                                  .OfType<CheckBox>()
                                  .All(c => c.Checked);

            btnConcluirDia.Enabled = todosMarcados;
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

                        // Atualiza progresso da barra e tela
                        diaAtual = (int)planoUser.ProgressoDiaAtual;
                        progressBar.Value = Math.Min(100, (int)((float)diaAtual / diasTotais * 100));
                        lblTitulo.Text = $"Dia {diaAtual} de {diasTotais}";

                        CarregarLeituraDoDia();
                    }
                    else
                    {
                        db.SaveChanges();
                        MessageBox.Show("Parabéns! Você concluiu o plano de leitura.");
                        this.Close();
                    }

                    ProgressoAtualizado?.Invoke(this, EventArgs.Empty);
                }
            }
        }

    }
}
