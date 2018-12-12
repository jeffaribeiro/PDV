using DesafioTotvsPDV.Data.Context;
using DesafioTotvsPDV.Domain.Entidades;
using DesafioTotvsPDV.Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTotvsPDV.Data.Repositorios
{
    public class ItemTrocoPagamentoRepository : IItemTrocoPagamentoRepository
    {
        private readonly MyContext _context;

        public ItemTrocoPagamentoRepository(MyContext context)
        {
            _context = context;
        }

        public List<ItemTrocoPagamento> Adicionar(List<ItemTrocoPagamento> itens)
        {
            _context.ItemTrocoPagamento.AddRange(itens);
            return itens;
        }
    }
}
