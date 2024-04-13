using ClinicaSanFelipe.Core.Entities;
using ClinicaSanFelipe.Core.Interfaces.Repositories;
using ClinicaSanFelipe.Infrastructure.Data;

namespace ClinicaSanFelipe.Infrastructure.Repositories
{
    public class MovimientoDetRepository : BaseRepository<Movimientodet>, IMovimientoDetRepository
    {
        public MovimientoDetRepository(ClinicaSanFelipeContext context) : base(context)
        {
        }
    }
}
