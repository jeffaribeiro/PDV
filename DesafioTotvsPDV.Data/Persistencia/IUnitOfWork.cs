using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTotvsPDV.Data.Persistencia
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
