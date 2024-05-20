using FerremaxApiModel;
using Microsoft.EntityFrameworkCore;

namespace FerremaxApi
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options):base(options) {}

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Producto>()
        //        .HasOne(p => p.Marca)
        //        .WithMany()
        //        .HasForeignKey(p => p.MarcaId)
        //        .OnDelete(DeleteBehavior.SetNull);

        //    modelBuilder.Entity<Producto>()
        //        .HasOne(p => p.TipoProducto)
        //        .WithMany()
        //        .HasForeignKey(p => p.TipoProductoId)
        //        .OnDelete(DeleteBehavior.SetNull);
        //}
    }
}
