using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Saca(double valor)
        {
            saldo -= valor;
        }

        public void Transfere(Conta contaDestino, double valor)
        {
            Saca(valor);
            contaDestino.Deposita(valor);
        }
    }
}
