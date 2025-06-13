using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeLightBible
{
    public partial class FormPlanoDiasAdmin : MaterialForm
    {
        private int planoLeituraId;

        public FormPlanoDiasAdmin(int planoId)
        {
            InitializeComponent();
            planoLeituraId = planoId;

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

            CarregarPlanos();

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

        private async void btnSalvarDia_Click(object sender, EventArgs e)
        {
            if (cmbPlanos.SelectedItem == null ||
                !int.TryParse(txtDia.Text, out int dia) ||
                string.IsNullOrWhiteSpace(txtCapitulos.Text))
            {
                MessageBox.Show("Preencha corretamente todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int planoId = (int)cmbPlanos.SelectedValue;

            using (var db = new Entities())
            {
                var novoDia = new PlanoLeituraModeloDia
                {
                    PlanoLeituraId = planoId,
                    Dia = dia,
                    Capitulos = txtCapitulos.Text.Trim()
                };

                db.PlanoLeituraModeloDia.Add(novoDia);
                db.SaveChanges();
            }

            MessageBox.Show("Dia adicionado com sucesso!");
            txtDia.Clear();
            txtCapitulos.Clear();
            await CarregarDiasPlanoSelecionado(); // opcional
        }

        private void cmbPlanos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDiasPlanoSelecionado();
        }

        private async Task CarregarDiasPlanoSelecionado()
        {
            if (cmbPlanos.SelectedItem == null) return;

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
