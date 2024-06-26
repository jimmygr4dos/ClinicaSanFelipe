﻿using ClinicaSanFelipe.Core.Entities;
using ClinicaSanFelipe.Core.Interfaces.Repositories;
using ClinicaSanFelipe.Infrastructure.Data;

namespace ClinicaSanFelipe.Infrastructure.Repositories
{
    public class MovimientoCabRepository : BaseRepository<MovimientoCab>, IMovimientoCabRepository
    {
        public MovimientoCabRepository(ClinicaSanFelipeContext context) : base(context)
        {
        }
    }
}
