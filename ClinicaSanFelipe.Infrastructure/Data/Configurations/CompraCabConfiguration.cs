using ClinicaSanFelipe.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaSanFelipe.Infrastructure.Data.Configurations
{
    internal class CompraCabConfiguration : IEntityTypeConfiguration<CompraCab>
    {
        public void Configure(EntityTypeBuilder<CompraCab> builder)
        {
            builder.HasKey(e => e.IdCompraCab)
                    .HasName("PK__CompraCa__09DEB65280A00F5A");

            builder.ToTable("CompraCab");

            builder.Property(e => e.IdCompraCab).HasColumnName("Id_CompraCab");

            builder.Property(e => e.FecRegistro)
                .HasColumnType("date")
                .HasColumnName("fecRegistro");
        }
    }
}
