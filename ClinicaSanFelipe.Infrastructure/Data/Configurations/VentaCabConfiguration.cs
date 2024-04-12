using ClinicaSanFelipe.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaSanFelipe.Infrastructure.Data.Configurations
{
    internal class VentaCabConfiguration : IEntityTypeConfiguration<VentaCab>
    {
        public void Configure(EntityTypeBuilder<VentaCab> builder)
        {
            builder.HasKey(e => e.IdVentaCab)
                    .HasName("PK__VentaCab__A066D95354C8CD2E");

            builder.ToTable("VentaCab");

            builder.Property(e => e.IdVentaCab).HasColumnName("Id_VentaCab");

            builder.Property(e => e.FecRegistro)
                .HasColumnType("date")
                .HasColumnName("fecRegistro");
        }
    }
}
