using System;

namespace DesafioTotvsPDV.Business.Exceptions
{
    public class PagamentoBusinessException : Exception
    {
        
        public PagamentoBusinessException()
        {
        }

        public PagamentoBusinessException(string message)
            : base(message)
        {
        }

        public PagamentoBusinessException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
