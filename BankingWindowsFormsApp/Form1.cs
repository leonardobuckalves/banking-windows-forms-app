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
    public partial class Form1 : Form
    {
        private Conta[] contas;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contas = new Conta[3];

            contas[0] = new Conta(1);
            contas[0].Titular = new Cliente("Leonardo");

            contas[1] = new ContaPoupanca(2);
            contas[1].Titular = new Cliente("Felipe");

            contas[2] = new ContaCorrente(3);
            contas[2].Titular = new Cliente("Renato");

            foreach (Conta conta in contas)
            {
                comboContas.Items.Add("Titular: " + conta.Titular.Nome);
            }
        }

        private void botaoDeposito_Click(object sender, EventArgs e)
        {
            int indice = comboContas.SelectedIndex;
            Conta selecionada = this.contas[indice];

            double valorOperacao = Convert.ToDouble(textoValor.Text);
            selecionada.Deposita(valorOperacao);
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
        }

        private void botaoSaque_Click(object sender, EventArgs e)
        {
            int indice = comboContas.SelectedIndex;
            Conta selecionada = this.contas[indice];

            double valorOperacao = Convert.ToDouble(textoValor.Text);
            if (selecionada.Saca(valorOperacao))
            {
                textoSaldo.Text = Convert.ToString(selecionada.Saldo);
            }
        }

        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = comboContas.SelectedIndex;
            Conta selecionada = contas[indice];
            textoNumero.Text = Convert.ToString(selecionada.Numero);
            textoTitular.Text = selecionada.Titular.Nome;
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
        }
    }
}
