using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartianRobots.Domain.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        T Get(int id);

        IReadOnlyList<T> GetAll();

        bool Exists(int id);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);
    }
}
