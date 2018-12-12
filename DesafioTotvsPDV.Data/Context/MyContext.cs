using DesafioTotvsPDV.Data.Extensions;
using DesafioTotvsPDV.Data.Mapeamentos;
using DesafioTotvsPDV.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DesafioTotvsPDV.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<ItemTrocoPagamento> ItemTrocoPagamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new PagamentoMap());
            modelBuilder.AddConfiguration(new ItemTrocoPagamentoMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
