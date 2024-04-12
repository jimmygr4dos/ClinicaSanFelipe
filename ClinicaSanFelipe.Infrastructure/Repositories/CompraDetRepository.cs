using ClinicaSanFelipe.Core.Entities;
using ClinicaSanFelipe.Core.Interfaces;
using ClinicaSanFelipe.Infrastructure.Data;

namespace ClinicaSanFelipe.Infrastructure.Repositories
{
    public class CompraDetRepository: BaseRepository<CompraDet>, ICompraDetRepository
    {
        public CompraDetRepository(ClinicaSanFelipeContext context): base(context)
        {
            
        }
    }
}
