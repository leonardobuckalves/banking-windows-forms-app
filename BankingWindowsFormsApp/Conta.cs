using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingWindowsFormsApp
{
    public abstract class Conta
    {
        public Conta(int numero)
        {
            this.Numero = numero;
        }

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
    }

    public class ContaPoupanca : Conta, ITributavel
    {
        public ContaPoupanca(int numero) : base(numero) { }

        public override void Deposita(double valor)
        {
            Saldo += valor;
            MessageBox.Show("Deposito realizado com sucesso");
        }
        public override bool Saca(double valor)
        {
            if (valor <= Saldo)
            {
                MessageBox.Show("Saque realizado com sucesso");
                Saldo -= valor + 0.10;
                return true;
            }
            else
            {
                MessageBox.Show("Saldo insuficiente");
                return false;
            }
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
            Saldo += valor - 0.10;
            MessageBox.Show("Deposito realizado com sucesso");
        }

        public override bool Saca(double valor)
        {
            if (valor <= Saldo)
            {
                MessageBox.Show("Saque realizado com sucesso");
                Saldo -= valor + 0.05;
                return true;
            }
            else
            {
                MessageBox.Show("Saldo insuficiente");
                return false;
            }
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
