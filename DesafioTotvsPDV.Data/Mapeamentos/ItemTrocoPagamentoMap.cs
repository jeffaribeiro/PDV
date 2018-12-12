using DesafioTotvsPDV.Data.Extensions;
using DesafioTotvsPDV.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTotvsPDV.Data.Mapeamentos
{
    public class ItemTrocoPagamentoMap : EntityTypeConfiguration<ItemTrocoPagamento>
    {
        public override void Map(EntityTypeBuilder<ItemTrocoPagamento> builder)
        {
            builder.ToTable("ItemTrocoPagamento");

            builder
                .HasOne(e => e.Pagamento)
                .WithMany(o => o.ItensTroco)
                .HasForeignKey(e => e.IdPagamento);
        }
    }
}
