using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingWindowsFormsApp.Contas
{
    public class ContaCorrente : Conta, ITributavel
    {
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
}
