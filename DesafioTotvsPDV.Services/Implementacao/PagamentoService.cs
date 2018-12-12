using DesafioTotvsPDV.Business.Interfaces;
using DesafioTotvsPDV.Domain.Entidades;
using DesafioTotvsPDV.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DesafioTotvsPDV.Services.Implementacao
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoBusiness _pagamentoBusiness;

        public PagamentoService(IPagamentoBusiness pagamentoBusiness)
        {
            _pagamentoBusiness = pagamentoBusiness;
        }

        public void Dispose()
        {
            return;
        }

        public string ExibirInfoTroco(decimal valorVenda, decimal valorPago)
        {
            try
            {
                var pagamento = _pagamentoBusiness.CalcularTroco(valorVenda, valorPago);
                var itensTroco = _pagamentoBusiness.ObterItensTroco(pagamento);
                var infoTroco = $"O troco de R$ " +
                    $"{string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", pagamento.ValorTroco.ToString("F2"))} " +
                    $"será pago com:{Environment.NewLine}";

                _pagamentoBusiness.SalvarPagamento(pagamento, itensTroco);

                foreach (var item in itensTroco.GroupBy(info => info.ValorObjetoTroco)
                            .Select(group => new
                            {
                                Metric = group.Key,
                                Count = group.Count()
                            })
                            .OrderByDescending(x => x.Metric))
                {
                    infoTroco = infoTroco + 
                        $"{item.Count.ToString()} item(ns)... de R$" +
                        $"{string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", item.Metric.ToString("F2"))}" +
                        $" {Environment.NewLine}";
                }

                return infoTroco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
