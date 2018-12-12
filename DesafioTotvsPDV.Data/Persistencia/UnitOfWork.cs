using DesafioTotvsPDV.Data.Context;

namespace DesafioTotvsPDV.Data.Persistencia
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;

        public UnitOfWork(MyContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
