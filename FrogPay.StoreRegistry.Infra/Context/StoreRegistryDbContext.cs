using FrogPay.StoreRegistry.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace FrogPay.StoreRegistry.Infra.Context
{
    public class StoreRegistryDbContext : DbContext
    {
        public StoreRegistryDbContext(DbContextOptions<StoreRegistryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<DadosBancarios> DadosBancarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Loja> Lojas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DadosBancarios>()
                .HasOne<Pessoa>()
                .WithMany(p => p.DadosBancarios)
                .HasForeignKey(d => d.IdPessoa);

            modelBuilder.Entity<Endereco>()
                .HasOne<Pessoa>()
                .WithMany(p => p.Enderecos)
                .HasForeignKey(e => e.IdPessoa);

            modelBuilder.Entity<Loja>()
                .HasOne<Pessoa>()
                .WithMany(p => p.Lojas)
                .HasForeignKey(l => l.IdPessoa);
        }
    }
}
