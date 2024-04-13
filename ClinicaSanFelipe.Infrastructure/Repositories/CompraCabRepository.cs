using ClinicaSanFelipe.Core.Entities;
using ClinicaSanFelipe.Core.Interfaces.Repositories;
using ClinicaSanFelipe.Infrastructure.Data;

namespace ClinicaSanFelipe.Infrastructure.Repositories
{
    public class CompraCabRepository: BaseRepository<CompraCab>, ICompraCabRepository
    {
        public CompraCabRepository(ClinicaSanFelipeContext context): base(context)
        {
            
        }
    }
}
