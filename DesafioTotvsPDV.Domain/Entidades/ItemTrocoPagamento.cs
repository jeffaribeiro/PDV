using DesafioTotvsPDV.Domain.Base;
using System;

namespace DesafioTotvsPDV.Domain.Entidades
{
    public class ItemTrocoPagamento : EntidadeBase
    {
        public Guid IdPagamento { get; private set; }
        public decimal ValorObjetoTroco { get; private set; }


        // propriedades de navegação EF Core
        public Pagamento Pagamento { get; private set; }

        // Construtor para o EFCore
        protected ItemTrocoPagamento() { }

        public ItemTrocoPagamento(Guid idPagamento, decimal valorObjetoTroco) {
            Id = Guid.NewGuid();
            IdPagamento = idPagamento;
            ValorObjetoTroco = valorObjetoTroco;
        }
    }
}
