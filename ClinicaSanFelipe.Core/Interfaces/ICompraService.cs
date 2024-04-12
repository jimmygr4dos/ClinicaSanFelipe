using ClinicaSanFelipe.Core.Entities;

namespace ClinicaSanFelipe.Core.Interfaces
{
    public interface ICompraService
    {
        Task<Compra?> GetById(int id);
        List<Compra> GetAll();
        Task Add(Compra compra);
        Task<bool> Update(Compra compra);
        Task<bool> Delete(int id);
    }
}
