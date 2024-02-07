using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingWindowsFormsApp.Contas
{
    public class SeguroDeVida : ITributavel
    {
        public double CalcularTributo()
        {
            return 42;
        }
    }
}
