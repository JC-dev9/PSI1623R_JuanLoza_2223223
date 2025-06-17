using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BeLightBible
{
    public partial class FormPlanoDiasAdmin : MaterialForm
    {
        private int planoLeituraId;
        private Livro livros = new Livro();

        public FormPlanoDiasAdmin(int planoId)
        {
            InitializeComponent();

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
                Accent.Orange400,
                TextShade.WHITE
            );

            cmbLivro.SelectedIndexChanged += cmbLivro_SelectedIndexChanged;
            cmbPlanos.SelectedIndexChanged += cmbPlanos_SelectedIndexChanged;

            CarregarPlanos();
            CarregarLivros();

            this.AcceptButton = null; // Remove o comportamento padrão de 'Enter' ativar o botão Salvar
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

        private void CarregarPlanos()
        {
            using (var db = new Entities())
            {
                var planos = db.PlanoLeitura
                               .Select(p => new { p.Id, p.Nome })
                               .ToList();

                cmbPlanos.DisplayMember = "Nome";
                cmbPlanos.ValueMember = "Id";
                cmbPlanos.DataSource = planos;
            }
        }

        private void btnSalvarDia_Click(object sender, EventArgs e)
        {
            // Validações
            if (cmbPlanos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um plano de leitura.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbLivro.SelectedItem == null)
            {
                MessageBox.Show("Selecione um livro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCapitulo.SelectedItem == null)
            {
                MessageBox.Show("Selecione um capítulo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int planoId = (int)cmbPlanos.SelectedValue;
            int dia = (int)numericUpDownDia.Value;
            string capitulo = cmbCapitulo.SelectedItem.ToString();

            using (var db = new Entities())
            {
                // Verifica se o dia já foi cadastrado no plano para evitar duplicidade
                bool diaExiste = db.PlanoLeituraModeloDia.Any(d => d.PlanoLeituraId == planoId && d.Dia == dia);
                if (diaExiste)
                {
                    MessageBox.Show($"O dia {dia} já está registrado neste plano.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var novoDia = new PlanoLeituraModeloDia
                {
                    PlanoLeituraId = planoId,
                    Dia = dia,
                    Capitulos = capitulo
                };

                db.PlanoLeituraModeloDia.Add(novoDia);
                db.SaveChanges();
            }

            MessageBox.Show("Dia adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Atualiza lista de dias
            CarregarDiasPlanoSelecionado();

            // Limpa seleção dos combos e incrementa o numericUpDown para o próximo dia automaticamente
            cmbLivro.SelectedIndex = -1;
            cmbCapitulo.Items.Clear();
            numericUpDownDia.Value += 1;
        }

        private void cmbPlanos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDiasPlanoSelecionado();
        }

        private void CarregarDiasPlanoSelecionado()
        {
            if (cmbPlanos.SelectedItem == null)
            {
                listDias.Items.Clear();
                return;
            }

            int planoId = (int)cmbPlanos.SelectedValue;

            using (var db = new Entities())
            {
                var dias = db.PlanoLeituraModeloDia
                             .Where(d => d.PlanoLeituraId == planoId)
                             .OrderBy(d => d.Dia)
                             .ToList();

                listDias.Items.Clear();
                foreach (var d in dias)
                {
                    listDias.Items.Add(new MaterialListBoxItem($"Dia {d.Dia}: {d.Capitulos}"));
                }
            }
        }
    }
}
