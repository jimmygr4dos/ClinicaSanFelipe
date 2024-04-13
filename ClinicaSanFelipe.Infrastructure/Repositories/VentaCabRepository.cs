using ClinicaSanFelipe.Core.Entities;
using ClinicaSanFelipe.Core.Interfaces.Repositories;
using ClinicaSanFelipe.Infrastructure.Data;

namespace ClinicaSanFelipe.Infrastructure.Repositories
{
    public class VentaCabRepository : BaseRepository<VentaCab>, IVentaCabRepository
    {
        public VentaCabRepository(ClinicaSanFelipeContext context) : base(context)
        {
        }
    }
}
