using Banca.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Banca.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<TitularTarjeta> TitularesTarjeta { get; set; } = null!;
        public DbSet<Compra> Compras { get; set; } = null!;
        public DbSet<Pago> Pagos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TitularTarjeta>()
                .HasMany(t => t.Compras)
                .WithOne(c => c.TitularTarjeta)
                .HasForeignKey(c => c.TitularTarjetaId);
            modelBuilder.Entity<TitularTarjeta>()
                .HasMany(t => t.Pagos)
                .WithOne(p => p.TitularTarjeta)
                .HasForeignKey(p => p.TitularTarjetaId);
        }
    }
}
