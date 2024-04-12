using ClinicaSanFelipe.Core.Entities;
using ClinicaSanFelipe.Core.Interfaces;

namespace ClinicaSanFelipe.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unit;
        public SecurityService(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<Security> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _unit.SecurityRepository.GetLoginByCredential(userLogin);
        }

        public async Task RegisterUser(Security security)
        {
            await _unit.SecurityRepository.Add(security);
            await _unit.SaveChangesAsync();
        }
    }
}
