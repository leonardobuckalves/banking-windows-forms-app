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
        private int numeroDeContas;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.contas = new Conta[10];

            Conta c1 = new ContaPoupanca();
            c1.Titular = new Cliente("Leonardo");
            AdicionaConta(c1);

            Conta c2 = new ContaPoupanca();
            c2.Titular = new Cliente("Felipe");
            AdicionaConta(c2);

            Conta c3 = new ContaCorrente();
            c3.Titular = new Cliente("Renato");
            AdicionaConta(c3);
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

        public void AdicionaConta(Conta conta)
        {
            contas[numeroDeContas] = conta;
            numeroDeContas++;
            comboContas.Items.Add("Titular: " + conta.Titular.Nome);
        }

        private void botaoNovaConta_Click(object sender, EventArgs e)
        {
            FormCadastroConta formularioDeCadastro = new FormCadastroConta(this);
            formularioDeCadastro.ShowDialog();
        }

        private void botaoImpostos_Click(object sender, EventArgs e)
        {
            ContaCorrente conta = new ContaCorrente();
            conta.Deposita(200.0);
            MessageBox.Show("imposta da conta corrente: " + conta.CalcularTributo());
            
            ITributavel t = conta;
            MessageBox.Show("imposto da conta pela interface: " + t.CalcularTributo());

            SeguroDeVida sv = new SeguroDeVida();
            MessageBox.Show("imposto do seguro: " + sv.CalcularTributo());

            t = sv;
            MessageBox.Show("imposto da conta pela interface: " + t.CalcularTributo());
        }
    }
}
