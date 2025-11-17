using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservation.src.AirlineReservation.Application.Interfaces;
using AirlineReservation.src.AirlineReservation.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservation.src.AirlineReservation.Infrastructure.Repositories
{
    internal class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly AirlineReservationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(AirlineReservationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public T? GetById(Guid id) => _dbSet.Find(id);

        public void Add(T entity) => _dbSet.Add(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Delete(Guid id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null) _dbSet.Remove(entity);
        }

        public void Save() => _context.SaveChanges();
    }
}
