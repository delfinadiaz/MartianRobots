using MartianRobots.Domain.Interfaces;
using MartianRobots.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MartianRobots.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MartianRobotsDbContext _dbContext;

        public GenericRepository(MartianRobotsDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public T Add(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public bool Exists(int id)
        {
            var entity = Get(id);
            return entity != null;
        }

        public T Get(int id)
        {
            return  _dbContext.Set<T>().Find(id);
        }

        public IReadOnlyList<T> GetAll()
        {
            return  _dbContext.Set<T>().ToList();
        }

        public T Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
