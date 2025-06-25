using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Windows.Forms;

namespace BeLightBible
{
    public partial class FormPlanoDiasAdmin : MaterialForm
    {
        private int planoLeituraId;
        private int diasMaximo;
        private Livro livros = new Livro();

        private Estilo estilo = new Estilo();

        private int diaAtual = 1;

        public FormPlanoDiasAdmin(int planoId)
        {

            InitializeComponent();

            // Estilização
            estilo.EstilizarPictureBoxComoBotao(picBtnProximoDia);
            estilo.EstilizarPictureBoxComoBotao(picBtnAnteriorDia);
            estilo.ArredondarControle(picBtnProximoDia, 10);
            estilo.ArredondarControle(picBtnAnteriorDia, 10);

            // Desativa a validação automática que pode travar o foco e gerar mensagens indesejadas
            this.AutoValidate = AutoValidate.Disable;

            planoLeituraId = planoId;

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

            cmbLivro.SelectedIndexChanged += cmbLivro_SelectedIndexChanged;

            CarregarLivros();

            this.AcceptButton = null; // Remove o comportamento padrão de 'Enter' ativar o botão Salvar

            btnVoltarTelaAdmin.Text = "← Voltar";

            diasMaximo = ObterDiasMaximoPlano(planoLeituraId);
            CarregarCapitulosDoDia();

            diasMaximo = ObterDiasMaximoPlano(planoLeituraId);

            numericUpDownDia.Minimum = 1;
            numericUpDownDia.Maximum = diasMaximo;
            numericUpDownDia.Value = 1;
            numericUpDownDia.Enabled = false;

            CarregarCapitulosDoDia();

        }

        private void CarregarLivros()
        {
            cmbLivro.Items.Clear();

            var livrosDictionary = livros.ObterLivros();

            foreach (var livro in livrosDictionary)
            {
                cmbLivro.Items.Add(livro.Key);
            }
        }

        private void cmbLivro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomeLivro = cmbLivro.SelectedItem as string;

            cmbCapitulo.Items.Clear();

            if (string.IsNullOrEmpty(nomeLivro))
                return;

            int totalCapitulos = livros.ObterNumeroDeCapitulos(nomeLivro);

            for (int i = 1; i <= totalCapitulos; i++)
            {
                cmbCapitulo.Items.Add(i.ToString());
            }

            if (cmbCapitulo.Items.Count > 0)
                cmbCapitulo.SelectedIndex = 0;
        }

        private string ObterNomePlano(int id)
        {
            using (var db = new Entities())
            {
                return db.PlanoLeitura.FirstOrDefault(p => p.Id == id)?.Nome ?? "Plano";
            }
        }

        private void picBtnAnteriorDia_Click(object sender, EventArgs e)
        {
            if (diaAtual > 1)
            {
                numericUpDownDia.Value--;
                diaAtual--;
                CarregarCapitulosDoDia();
            }
        }

        private void picBtnProximoDia_Click(object sender, EventArgs e)
        {
            if (diaAtual < diasMaximo)
            {
                numericUpDownDia.Value++;
                diaAtual++;
                CarregarCapitulosDoDia();
            }
        }

        private void btnSalvarDia_Click(object sender, EventArgs e)
        {
            if (cmbLivro.SelectedItem == null || cmbCapitulo.SelectedItem == null)
            {
                MessageBox.Show("Selecione o livro e o capítulo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string livro = cmbLivro.SelectedItem.ToString();
            string capitulo = cmbCapitulo.SelectedItem.ToString();
            string capituloCompleto = $"{livro} {capitulo}";

            using (var db = new Entities())
            {
                // Busca o registro do dia e plano
                var registroExistente = db.PlanoLeituraModeloDia
                    .FirstOrDefault(r => r.PlanoLeituraId == planoLeituraId && r.Dia == diaAtual);

                if (registroExistente != null)
                {
                    // Se já tem capítulos, adiciona o novo (evitando repetição)
                    var capitulosExistentes = registroExistente.Capitulos?.Split(',')
                        .Select(c => c.Trim())
                        .ToList() ?? new List<string>();

                    if (!capitulosExistentes.Contains(capituloCompleto))
                    {
                        capitulosExistentes.Add(capituloCompleto);
                        registroExistente.Capitulos = string.Join(", ", capitulosExistentes);
                        db.Entry(registroExistente).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        MessageBox.Show("Esse capítulo já está adicionado para hoje.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    // Não existe, cria novo registro
                    var novoCapitulo = new PlanoLeituraModeloDia
                    {
                        PlanoLeituraId = planoLeituraId,
                        Dia = diaAtual,
                        Capitulos = capituloCompleto
                    };
                    db.PlanoLeituraModeloDia.Add(novoCapitulo);
                }

                db.SaveChanges();
            }

            MessageBox.Show("Capítulo adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CarregarCapitulosDoDia();

            cmbLivro.SelectedIndex = -1;
            cmbCapitulo.Items.Clear();
        }



        private int ObterDiasMaximoPlano(int planoId)
        {
            using (var db = new Entities())
            {
                return db.PlanoLeitura
                         .Where(p => p.Id == planoId)
                         .Select(p => p.DiasDuracao)    
                         .FirstOrDefault();
            }
        }
        private void CarregarCapitulosDoDia()
        {
            listDia.Items.Clear();

            using (var db = new Entities())
            {
                var capitulos = db.PlanoLeituraModeloDia
                                  .Where(d => d.PlanoLeituraId == planoLeituraId && d.Dia == diaAtual)
                                  .Select(d => d.Capitulos)
                                  .ToList();

                foreach (var cap in capitulos)
                {
                    // Separar capítulos pela vírgula, remover espaços extras e adicionar um por um
                    var capitulosSeparados = cap.Split(',')
                                               .Select(c => c.Trim())
                                               .Where(c => !string.IsNullOrEmpty(c));

                    foreach (var capitulo in capitulosSeparados)
                    {
                        listDia.Items.Add(new MaterialListBoxItem(capitulo));
                    }
                }
            }
        }


        private void btnVoltarTelaAdmin_Click(object sender, EventArgs e)
        {
            var telaAdmin = new MenuAdmin(); // substitua pelo nome da tela anterior
            telaAdmin.Show();
            this.Close(); // Fecha o formulário atual
        }
    }
}
