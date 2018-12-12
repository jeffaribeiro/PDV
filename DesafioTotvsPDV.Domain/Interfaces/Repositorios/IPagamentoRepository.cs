using DesafioTotvsPDV.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTotvsPDV.Domain.Interfaces.Repositorios
{
    public interface IPagamentoRepository
    {
        Pagamento Adicionar(Pagamento pagamento);
    }
}
