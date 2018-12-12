using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTotvsPDV.API.Inputs
{
    public class PagamentoInput: IInput
    {
        public decimal ValorVenda { get; set; }
        public decimal ValorPago { get; set; }

        public bool EhValido()
        {
            return ValorPagoEhValido() && ValorVendaNaoEhNegativo();
        }

        private bool ValorPagoEhValido()
        {
            return ValorPago >= ValorVenda;
        }

        private bool ValorVendaNaoEhNegativo()
        {
            return ValorVenda >= 0;
        }
    }
}
