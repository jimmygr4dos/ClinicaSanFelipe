using ClinicaSanFelipe.Core.Enumerations;

namespace ClinicaSanFelipe.Core.Entities
{
    public class Security
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleType Role { get; set; }
    }
}
