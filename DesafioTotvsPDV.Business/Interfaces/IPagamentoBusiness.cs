using DesafioTotvsPDV.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTotvsPDV.Business.Interfaces
{
    public interface IPagamentoBusiness
    {
        Pagamento CalcularTroco(decimal valorVenda, decimal valorPago);
        List<ItemTrocoPagamento> ObterItensTroco(Pagamento pagamento);
        void SalvarPagamento(Pagamento pagamento, List<ItemTrocoPagamento> itensTrocoPagamento);
    }
}
