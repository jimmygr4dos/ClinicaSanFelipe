using ClinicaSanFelipe.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaSanFelipe.Infrastructure.Data.Configurations
{
    internal class MovimientodetConfiguration : IEntityTypeConfiguration<Movimientodet>
    {
        public void Configure(EntityTypeBuilder<Movimientodet> builder)
        {
            builder.HasKey(e => e.IdMovimientoDet)
                    .HasName("PK__Movimien__04265FBBE5E7D80C");

            builder.ToTable("Movimientodet");

            builder.Property(e => e.IdMovimientoDet).HasColumnName("Id_MovimientoDet");

            builder.Property(e => e.Cantidad).HasColumnName("cantidad");

            builder.Property(e => e.IdMovimientoCab).HasColumnName("Id_MovimientoCab");

            builder.Property(e => e.IdProducto).HasColumnName("Id_Producto");

            builder.HasOne(d => d.IdMovimientoCabNavigation)
                .WithMany(p => p.Movimientodets)
                .HasForeignKey(d => d.IdMovimientoCab)
                .HasConstraintName("FK_Movimientodet_MovimientoCab");

            builder.HasOne(d => d.IdProductoNavigation)
                .WithMany(p => p.Movimientodets)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_Movimientodet_Productos");
        }
    }
}
