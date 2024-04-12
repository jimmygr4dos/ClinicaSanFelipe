using ClinicaSanFelipe.Core.Entities;
using ClinicaSanFelipe.Core.Interfaces;
using ClinicaSanFelipe.Infrastructure.Data;

namespace ClinicaSanFelipe.Infrastructure.Repositories
{
    public class ProductoRepository: BaseRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(ClinicaSanFelipeContext context): base (context) { }

    }
}
