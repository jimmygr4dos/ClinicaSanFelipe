using ClinicaSanFelipe.Core.Entities;
using ClinicaSanFelipe.Core.Interfaces.Repositories;
using ClinicaSanFelipe.Infrastructure.Data;

namespace ClinicaSanFelipe.Infrastructure.Repositories
{
    public class VentaDetRepository : BaseRepository<VentaDet>, IVentaDetRepository
    {
        public VentaDetRepository(ClinicaSanFelipeContext context) : base(context)
        {
        }
    }
}
