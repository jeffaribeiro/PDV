using System;
using FluentValidation;
using FluentValidation.Results;

namespace DesafioTotvsPDV.Domain.Base
{
    public class EntidadeBase
    {
        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; protected set; }
        
    }
}
