using ClinicaSanFelipe.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaSanFelipe.Infrastructure.Data.Configurations
{
    internal class CompraDetConfiguration : IEntityTypeConfiguration<CompraDet>
    {
        public void Configure(EntityTypeBuilder<CompraDet> builder)
        {
            builder.HasKey(e => e.IdCompraDet)
                    .HasName("PK__CompraDe__099EDE6C2AC40F32");

            builder.ToTable("CompraDet");

            builder.Property(e => e.IdCompraDet).HasColumnName("Id_CompraDet");

            builder.Property(e => e.Cantidad).HasColumnName("cantidad");

            builder.Property(e => e.IdCompraCab).HasColumnName("Id_CompraCab");

            builder.Property(e => e.IdProducto).HasColumnName("Id_producto");

            builder.Property(e => e.Igv).HasColumnName("IGV");

            builder.Property(e => e.SubTotal).HasColumnName("Sub_Total");

            builder.HasOne(d => d.IdCompraCabNavigation)
                .WithMany(p => p.CompraDets)
                .HasForeignKey(d => d.IdCompraCab)
                .HasConstraintName("FK_CompraDet_CompraCab");

            builder.HasOne(d => d.IdProductoNavigation)
                .WithMany(p => p.CompraDets)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_CompraDet_Productos");
        }
    }
}
