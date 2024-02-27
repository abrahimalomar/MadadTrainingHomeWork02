using System;
using System.Collections.Generic;


namespace Domain.interfaces
{
    public interface IGenericRepository<T> where T:IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T RetrieveById(Func<T, bool> predicate);

    }
}
