using ClinicaSanFelipe.Core.Entities;

namespace ClinicaSanFelipe.Core.Interfaces.Repositories
{
    public interface ISecurityRepository : IRepository<Security>
    {
        Task<Security> GetLoginByCredential(UserLogin login);
    }
}
