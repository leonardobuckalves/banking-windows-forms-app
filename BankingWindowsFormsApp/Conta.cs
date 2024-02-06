using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingWindowsFormsApp
{
    public class Conta
    {
        public int Numero { get; set; }
        public Cliente Titular { get; set; }
        public double Saldo { get; private set; }

        public void Deposita(double valor)
        {
            Saldo += valor;
            MessageBox.Show("Deposito realizado com sucesso");
        }

        public bool Saca(double valor)
        {
            if (valor <= Saldo)
            {
                MessageBox.Show("Saque realizado com sucesso");
                Saldo -= valor;
                return true;
            }
            else
            {
                MessageBox.Show("Saldo insuficiente");
                return false;
            }
        }

        public void Transfere(Conta contaDestino, double valor)
        {
            Saca(valor);
            contaDestino.Deposita(valor);
        }
    }
}
