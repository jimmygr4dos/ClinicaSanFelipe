using ClinicaSanFelipe.Core.Entities;

namespace ClinicaSanFelipe.Core.Interfaces.Services
{
    public interface IVentaService
    {
        Task<Venta?> GetById(int id);
        List<Venta> GetAll();
        Task Add(Venta venta);
        Task<bool> Update(Venta venta);
        Task<bool> Delete(int id);
    }
}
