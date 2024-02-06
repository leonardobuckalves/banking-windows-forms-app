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
            conta.numero = 1;
            conta.titular = cliente;
            conta.titular.nome = "Cliente";
            conta.saldo = 1000;

            MessageBox.Show("Criando nova conta");
            MessageBox.Show($"Conta: {conta.numero}, Titular: {conta.titular.nome}, Saldo: {conta.saldo}.");

            MessageBox.Show("Depositando 100");
            conta.Deposita(100);
            MessageBox.Show("Saldo: " + conta.saldo);
            MessageBox.Show("Sacando 300");
            if (conta.Saca(300))
            {
                MessageBox.Show("Novo saldo: " + conta.saldo);
            }

            // criar outro novo cliente
            Cliente cliente2 = new Cliente();

            // instanciar outra nova conta, mostrar os dados cadastrados, transferir da outra conta para essa conta
            Conta conta2 = new Conta();
            conta2.numero = 2;
            conta2.titular = cliente2;
            conta2.titular.nome = "Cliente2";
            conta2.saldo = 100;

            MessageBox.Show("Criando nova conta");
            MessageBox.Show($"Conta: {conta2.numero}, Titular: {conta2.titular.nome}, Saldo: {conta2.saldo}.");

            MessageBox.Show("Transferindo 600 de conta para conta2");
            conta.Transfere(conta2, 600);
            MessageBox.Show($"Conta: {conta.numero}, Titular: {conta.titular.nome}, Saldo: {conta.saldo}.");
            MessageBox.Show($"Conta: {conta2.numero}, Titular: {conta2.titular.nome}, Saldo: {conta2.saldo}.");
        }
    }
}
