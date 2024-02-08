using BankingWindowsFormsApp.Contas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingWindowsFormsApp
{
    public partial class FormRelatorios : Form
    {
        private List<Conta> contas;

        public FormRelatorios(List<Conta> contas)
        {
            InitializeComponent();
            this.contas = contas;
        }

        private void botaoFiltroSaldo_Click(object sender, EventArgs e)
        {
            listaResultado.Items.Clear();
            var resultado = contas
                .Where(c => c.Saldo > 100)
                .OrderBy(c => c.Titular.Nome)
                .ThenBy(c => c.Numero);

            foreach (var c in resultado)
            {
                listaResultado.Items.Add(c);
            }

            double saldoTotal = resultado.Sum(conta => conta.Saldo);
            double maiorSaldo = resultado.Max(conta => conta.Saldo);

            labelSaldoTotal.Text = Convert.ToString(saldoTotal);
            labelMaiorSaldo.Text = Convert.ToString(maiorSaldo);
        }
    }
}
