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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // criar novo cliente
            Cliente cliente = new Cliente();

            // instanciar uma nova conta, mostrar os dados cadastrados, depositar e sacar valores
            Conta conta = new Conta();
            conta.Numero = 1;
            conta.Titular = cliente;
            conta.Titular.Nome = "Cliente";
            conta.Deposita(1000);
            

            MessageBox.Show("Criando nova conta");
            MessageBox.Show($"Conta: {conta.Numero}, Titular: {conta.Titular.nome}, Saldo: {conta.Saldo}.");

            MessageBox.Show("Depositando 100");
            conta.Deposita(100);
            MessageBox.Show("Saldo: " + conta.Saldo);
            MessageBox.Show("Sacando 300");
            if (conta.Saca(300))
            {
                MessageBox.Show("Novo saldo: " + conta.Saldo);
            }

            // criar outro novo cliente
            Cliente cliente2 = new Cliente();

            // instanciar outra nova conta, mostrar os dados cadastrados, transferir da outra conta para essa conta
            Conta conta2 = new Conta();
            conta2.Numero = 2;
            conta2.Titular = cliente2;
            conta2.Titular.Nome = "Cliente2";
            conta2.Deposita(100);

            MessageBox.Show("Criando nova conta");
            MessageBox.Show($"Conta: {conta2.Numero}, Titular: {conta2.Titular.nome}, Saldo: {conta2.Saldo}.");

            MessageBox.Show("Transferindo 600 de conta para conta2");
            conta.Transfere(conta2, 600);
            MessageBox.Show($"Conta: {conta.Numero}, Titular: {conta.Titular.nome}, Saldo: {conta.Saldo}.");
            MessageBox.Show($"Conta: {conta2.Numero}, Titular: {conta2.Titular.nome}, Saldo: {conta2.Saldo}.");
        }
    }
}
