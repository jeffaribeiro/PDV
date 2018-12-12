using DesafioTotvsPDV.Domain.Entidades;
using System.Collections.Generic;

namespace DesafioTotvsPDV.Domain.Interfaces.Repositorios
{
    public interface IItemTrocoPagamentoRepository
    {
        List<ItemTrocoPagamento> Adicionar(List<ItemTrocoPagamento> itens);
    }
}
