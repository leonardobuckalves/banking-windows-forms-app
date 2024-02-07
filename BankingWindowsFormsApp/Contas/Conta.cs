using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingWindowsFormsApp.Contas
{
    public abstract class Conta
    {
        public Conta()
        {
            Conta.numeroDeContas++;
            Numero = Conta.numeroDeContas;
        }

        private static int numeroDeContas;

        public int Numero { get; set; }
        public Cliente Titular { get; set; }
        public double Saldo { get; protected set; }

        public abstract void Deposita(double valor);

        public abstract bool Saca(double valor);

        public void Transfere(Conta contaDestino, double valor)
        {
            Saca(valor);
            contaDestino.Deposita(valor);
        }

        public static int ProximoNumero()
        {
            return numeroDeContas + 1;
        }

        public override String ToString()
        {
            return "Titular: " + Titular.Nome;
        }
    }
}
