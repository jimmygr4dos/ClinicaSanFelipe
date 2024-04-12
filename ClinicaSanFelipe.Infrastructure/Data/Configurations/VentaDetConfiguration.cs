using ClinicaSanFelipe.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaSanFelipe.Infrastructure.Data.Configurations
{
    internal class VentaDetConfiguration : IEntityTypeConfiguration<VentaDet>
    {
        public void Configure(EntityTypeBuilder<VentaDet> builder)
        {
            builder.HasKey(e => e.IdVentaDet)
                    .HasName("PK__VentaDet__A026FB373F318573");

            builder.ToTable("VentaDet");

            builder.Property(e => e.IdVentaDet).HasColumnName("Id_VentaDet");

            builder.Property(e => e.Cantidad).HasColumnName("cantidad");

            builder.Property(e => e.IdProducto).HasColumnName("Id_producto");

            builder.Property(e => e.IdVentaCab).HasColumnName("Id_VentaCab");

            builder.Property(e => e.Igv).HasColumnName("IGV");

            builder.Property(e => e.SubTotal).HasColumnName("Sub_Total");

            builder.HasOne(d => d.IdProductoNavigation)
                .WithMany(p => p.VentaDets)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_VentaDet_Productos");

            builder.HasOne(d => d.IdVentaCabNavigation)
                .WithMany(p => p.VentaDets)
                .HasForeignKey(d => d.IdVentaCab)
                .HasConstraintName("FK_VentaDet_VentaCab");
        }
    }
}
