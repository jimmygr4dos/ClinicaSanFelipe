using ClinicaSanFelipe.Core.CustomEntities;
using ClinicaSanFelipe.Core.Entities;

namespace ClinicaSanFelipe.Core.Interfaces
{
    public interface IProductoService
    {
        Task<Producto> GetById(int id);
        PagedList<Producto> GetAll(int PageSize, int PageNumber);
        Task Add(Producto producto);
        Task<bool> Update(Producto producto);
        Task<bool> Delete(int id);
    }
}
