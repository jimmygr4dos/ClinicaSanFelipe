﻿using ClinicaSanFelipe.Core.Interfaces.Repositories;
using ClinicaSanFelipe.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicaSanFelipe.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly ClinicaSanFelipeContext _context;
        protected readonly DbSet<T> _entities;
        public BaseRepository(ClinicaSanFelipeContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }

    }
}
