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
            Conta conta = new Conta();
            conta.numero = 1;
            conta.titular = "Cliente";
            conta.saldo = 1000;

            MessageBox.Show($"Conta: {conta.numero}, Titular: {conta.titular}, Saldo: {conta.saldo}.");

            conta.Deposita(100);
            MessageBox.Show("Saldo: " + conta.saldo);
            conta.Saca(300);
            MessageBox.Show("Saldo: " + conta.saldo);
        }
    }
}
