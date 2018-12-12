using DesafioTotvsPDV.Domain.Base;
using System;
using System.Collections.Generic;

namespace DesafioTotvsPDV.Domain.Entidades
{
    public class Pagamento : EntidadeBase
    {
        public decimal ValorVenda { get; private set; }
        public decimal ValorPago { get; private set; }
        public decimal ValorTroco { get; private set; }
        public DateTime DataTransacao { get; private set; }

        // EF Propriedade de Navegação
        public virtual ICollection<ItemTrocoPagamento> ItensTroco { get; set; }

        // Construtor para o EFCore
        protected Pagamento() { }

        public Pagamento(decimal _valorVenda, decimal _valorPago)
        {
            Id = Guid.NewGuid();
            ValorVenda = _valorVenda;
            ValorPago = _valorPago;
            ValorTroco = ValorPago - ValorVenda;
            DataTransacao = DateTime.Now;
        }

        public bool ValorPagoEhValido()
        {
            return (ValorPago >= ValorVenda);
        }
    }
}
