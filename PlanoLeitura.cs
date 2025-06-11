using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BeLightBible
{
    public class PlanoLeitura
    {
        private TabPage tab;
        private Panel painelPrincipal;
        private MaterialLabel lblTitulo;
        private MaterialListView listaVersiculos;
        private MaterialButton btnMarcarComoLido;
        private MaterialProgressBar barraProgresso;
        private MaterialButton btnReiniciar;
        private MaterialButton btnVerCompleto;

        private List<string> trechosDoDia = new List<string> { "Gênesis 1", "Salmos 1", "Mateus 1" };

        public PlanoLeitura(TabPage tabDestino, Panel painel)
        {
            this.tab = tabDestino;
            this.painelPrincipal = painel;

            CriarComponentes();
            PreencherLista();
        }

        private void CriarComponentes()
        {
            // Título
            lblTitulo = new MaterialLabel
            {
                Text = $"Plano de Leitura ({DateTime.Now:dd/MM/yyyy})",
                Location = new Point(20, 20),
                AutoSize = true
            };

            // Lista de trechos
            listaVersiculos = new MaterialListView
            {
                Location = new Point(20, 60),
                Size = new Size(400, 140),
                View = View.Details,
                FullRowSelect = true,
                MultiSelect = false
            };
            listaVersiculos.Columns.Add("Trecho", 350);

            // Botão: Marcar como lido
            btnMarcarComoLido = new MaterialButton
            {
                Text = "Marcar como lido",
                Location = new Point(20, 210),
                AutoSize = true
            };
            btnMarcarComoLido.Click += BtnMarcarComoLido_Click;

            // Barra de progresso
            barraProgresso = new MaterialProgressBar
            {
                Location = new Point(20, 250),
                Size = new Size(400, 5),
                Value = 0
            };

            // Botões extras
            btnReiniciar = new MaterialButton
            {
                Text = "Reiniciar Plano",
                Location = new Point(20, 270),
                AutoSize = true
            };
            btnReiniciar.Click += BtnReiniciar_Click;

            btnVerCompleto = new MaterialButton
            {
                Text = "Ver Plano Completo",
                Location = new Point(180, 270),
                AutoSize = true
            };
            btnVerCompleto.Click += (s, e) =>
            {
                MessageBox.Show("Em breve: visualização do plano completo!");
            };

            // Adiciona ao painel
            painelPrincipal.Controls.Add(lblTitulo);
            painelPrincipal.Controls.Add(listaVersiculos);
            painelPrincipal.Controls.Add(btnMarcarComoLido);
            painelPrincipal.Controls.Add(barraProgresso);
            painelPrincipal.Controls.Add(btnReiniciar);
            painelPrincipal.Controls.Add(btnVerCompleto);
        }

        private void PreencherLista()
        {
            foreach (var trecho in trechosDoDia)
            {
                listaVersiculos.Items.Add(new ListViewItem(trecho));
            }
        }

        private void BtnMarcarComoLido_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listaVersiculos.Items)
                item.BackColor = Color.LightGreen;

            barraProgresso.Value = 100;
        }

        private void BtnReiniciar_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listaVersiculos.Items)
                item.BackColor = Color.White;

            barraProgresso.Value = 0;
        }
    }
}
