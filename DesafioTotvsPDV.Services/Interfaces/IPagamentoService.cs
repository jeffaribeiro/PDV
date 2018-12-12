using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTotvsPDV.Services.Interfaces
{
    public interface IPagamentoService : IServiceBase
    {
        string ExibirInfoTroco(decimal valorVenda, decimal valorPago);
    }
}
