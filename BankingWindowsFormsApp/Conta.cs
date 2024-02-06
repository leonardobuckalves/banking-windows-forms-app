using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingWindowsFormsApp
{
    internal class Conta
    {
        public int numero;
        public string titular;
        public double saldo;

        public void Deposita(double valor)
        {
            saldo += valor;
        }

        public bool Saca(double valor)
        {
            if (valor <= saldo)
            {
                MessageBox.Show("Saque realizado com sucesso");
                saldo -= valor;
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
