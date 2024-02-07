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
        public Conta(int numero)
        {
            this.Numero = numero;
        }

        public int Numero { get; set; }
        public Cliente Titular { get; set; }
        public double Saldo { get; private set; }

        public virtual void Deposita(double valor)
        {
            Saldo += valor;
            MessageBox.Show("Deposito realizado com sucesso");
        }

        public virtual bool Saca(double valor)
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

    public class ContaPoupanca : Conta, ITributavel
    {
        public ContaPoupanca(int numero) : base(numero) { }

        public override bool Saca(double valor)
        {
            return base.Saca(valor + 0.10);
        }

        public double CalcularTributo()
        {
            return Saldo * 0.02;
        }
    }

    public class ContaCorrente : Conta, ITributavel
    {
        public ContaCorrente(int numero) : base(numero) { }

        public override void Deposita(double valor)
        {
            base.Deposita(valor - 0.10);
        }

        public override bool Saca(double valor)
        {
            return base.Saca(valor + 0.05);
        }

        public double CalcularTributo()
        {
            return Saldo * 0.03;
        }
    }

    public class SeguroDeVida : ITributavel
    {
        public double CalcularTributo()
        {
            return 42;
        }
    }
}
