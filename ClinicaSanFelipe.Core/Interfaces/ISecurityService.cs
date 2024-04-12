using ClinicaSanFelipe.Core.Entities;

namespace ClinicaSanFelipe.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}
