using ClinicaSanFelipe.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClinicaSanFelipe.Infrastructure.Data
{
    public partial class ClinicaSanFelipeContext : DbContext
    {
        public ClinicaSanFelipeContext()
        {
        }

        public ClinicaSanFelipeContext(DbContextOptions<ClinicaSanFelipeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompraCab> CompraCabs { get; set; } = null!;
        public virtual DbSet<CompraDet> CompraDets { get; set; } = null!;
        public virtual DbSet<MovimientoCab> MovimientoCabs { get; set; } = null!;
        public virtual DbSet<Movimientodet> Movimientodets { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<VentaCab> VentaCabs { get; set; } = null!;
        public virtual DbSet<VentaDet> VentaDets { get; set; } = null!;
        public virtual DbSet<Security> Securities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
