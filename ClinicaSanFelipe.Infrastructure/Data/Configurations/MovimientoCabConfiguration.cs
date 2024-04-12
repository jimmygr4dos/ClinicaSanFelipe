using ClinicaSanFelipe.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaSanFelipe.Infrastructure.Data.Configurations
{
    internal class MovimientoCabConfiguration : IEntityTypeConfiguration<MovimientoCab>
    {
        public void Configure(EntityTypeBuilder<MovimientoCab> builder)
        {
            builder.HasKey(e => e.IdMovimientoCab)
                    .HasName("PK__Movimien__04664D137F4333C9");

            builder.ToTable("MovimientoCab");

            builder.Property(e => e.IdMovimientoCab).HasColumnName("Id_MovimientoCab");

            builder.Property(e => e.FecRegistro)
                .HasColumnType("date")
                .HasColumnName("fec_registro");

            builder.Property(e => e.IdDocumentoOrigen).HasColumnName("Id_DocumentoOrigen");

            builder.Property(e => e.IdTipoMovimiento).HasColumnName("Id_TipoMovimiento");
        }
    }
}
