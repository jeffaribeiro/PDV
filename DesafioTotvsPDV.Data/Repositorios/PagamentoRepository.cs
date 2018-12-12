using DesafioTotvsPDV.Data.Context;
using DesafioTotvsPDV.Domain.Entidades;
using DesafioTotvsPDV.Domain.Interfaces.Repositorios;

namespace DesafioTotvsPDV.Data.Repositorios
{
    public class PagamentoRepository : IPagamentoRepository
    {

        private readonly MyContext _context;

        public PagamentoRepository(MyContext context)
        {
            _context = context;
        }

        public Pagamento Adicionar(Pagamento pagamento)
        {
            _context.Pagamento.Add(pagamento);

            return pagamento;
        }
    }
}
