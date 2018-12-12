using DesafioTotvsPDV.Data.Extensions;
using DesafioTotvsPDV.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioTotvsPDV.Data.Mapeamentos
{
    public class PagamentoMap : EntityTypeConfiguration<Pagamento>
    {
        public override void Map(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamento");
        }
    }
}
