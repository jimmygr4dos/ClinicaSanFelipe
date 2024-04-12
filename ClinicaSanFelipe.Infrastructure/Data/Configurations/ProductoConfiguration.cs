using ClinicaSanFelipe.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaSanFelipe.Infrastructure.Data.Configurations
{
    internal class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__1D8EFF01416E3DE6");

            builder.Property(e => e.IdProducto).HasColumnName("Id_producto");

            builder.Property(e => e.FecRegistro)
                .HasColumnType("date")
                .HasColumnName("Fec_registro");

            builder.Property(e => e.Moneda)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("moneda")
                .IsFixedLength();

            builder.Property(e => e.NombreProducto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Nombre_producto");

            builder.Property(e => e.NroLote)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nroLote");

            builder.Property(e => e.PrecioVenta).HasColumnName("precioVenta");
        }
    }
}
