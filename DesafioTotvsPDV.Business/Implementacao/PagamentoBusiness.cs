using DesafioTotvsPDV.Business.Exceptions;
using DesafioTotvsPDV.Business.Interfaces;
using DesafioTotvsPDV.Data.Context;
using DesafioTotvsPDV.Domain.Constantes;
using DesafioTotvsPDV.Domain.Entidades;
using DesafioTotvsPDV.Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioTotvsPDV.Business.Implementacao
{
    public class PagamentoBusiness : IPagamentoBusiness
    {

        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IItemTrocoPagamentoRepository _itemTrocoPagamentoRepository;


        public PagamentoBusiness(IPagamentoRepository pagamentoRepository, IItemTrocoPagamentoRepository itemTrocoPagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
            _itemTrocoPagamentoRepository = itemTrocoPagamentoRepository;
        }

        private decimal[] ObjetosDisponiveisParaTroco =
            {
              ObjetoTroco.Nota.Nota100Reais,
              ObjetoTroco.Nota.Nota050Reais,
              ObjetoTroco.Nota.Nota020Reais,
              ObjetoTroco.Nota.Nota010Reais,
              ObjetoTroco.Moeda.Moeda50Centavos,
              ObjetoTroco.Moeda.Moeda10Centavos,
              ObjetoTroco.Moeda.Moeda05Centavos,
              ObjetoTroco.Moeda.Moeda01Centavo
            };

        public Pagamento CalcularTroco(decimal valorVenda, decimal valorPago)
        {
            Pagamento pagamento = new Pagamento(valorVenda, valorPago);

            if (!pagamento.ValorPagoEhValido())
                throw new PagamentoBusinessException("Não foi possível realizar a transação. O valor pago é menor que o valor da venda.");

            return pagamento;
        }

        public List<ItemTrocoPagamento> ObterItensTroco(Pagamento pagamento)
        {
            List<ItemTrocoPagamento> itensTrocoPagamento = new List<ItemTrocoPagamento>();
            decimal valorRestante = pagamento.ValorTroco;

            foreach (var valorObjetoTroco in this.ObjetosDisponiveisParaTroco)
            {
                int qtdItens, i;

                qtdItens = (int)(valorRestante / valorObjetoTroco);

                if (qtdItens > 0)
                {
                    i = 0;
                    while (i < qtdItens)
                    {
                        ItemTrocoPagamento itemTrocoPagamento = new ItemTrocoPagamento(pagamento.Id, valorObjetoTroco);
                        itensTrocoPagamento.Add(itemTrocoPagamento);
                        i += 1;
                    }
                }

                valorRestante = valorRestante - (qtdItens * valorObjetoTroco);
            }

            if (itensTrocoPagamento.Sum(x => x.ValorObjetoTroco) != pagamento.ValorTroco)
                throw new PagamentoBusinessException("Não foi possível realizar a transação. Erro ao contar os itens para devolução do troco.");

            return itensTrocoPagamento;
        }

        public void SalvarPagamento(Pagamento pagamento, List<ItemTrocoPagamento> itensTrocoPagamento)
        {
            try
            {
                _pagamentoRepository.Adicionar(pagamento);
                _itemTrocoPagamentoRepository.Adicionar(itensTrocoPagamento);
            }
            catch (Exception ex)
            {
                throw new PagamentoBusinessException($"Não foi possível realizar a transação. Erro um erro ao gravar as" +
                    $" informações no servidor: {ex.Message}");
            }
        }

        public void Dispose()
        {
            return;
        }
    }
}