﻿using ClinicaSanFelipe.Core.Enumerations;

namespace ClinicaSanFelipe.Core.DTOs
{
    public class SecurityDTO
    {
        public string User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleType? Role { get; set; }
    }
}
