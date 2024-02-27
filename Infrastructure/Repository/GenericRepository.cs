using Domain.interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Infrastructure.Repository
{
 public class GenericRepository<T> :
        IGenericRepository<T> where T : IEntity
        {
        public DB<T> DB;
        public GenericRepository(DB<T> dB)
        {
           this.DB = dB;
        }
        public void Add(T entity)
        {
            DB.db.Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity != null)
            {
                DB.db.Remove(entity);
            }
            else
            {
                throw new ArgumentException($"Entity  not found.");
            }
        }

        public IEnumerable<T> GetAll()
        {
          return  DB.db;
        }

        public T GetById(int Id)
        {
            try
            {
                return DB.db.Find(entity => entity.Id == Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving data: {ex.Message}");
                return default(T); 
            }
        }
        public void Update(T entity)
        {
            if (entity != null)
            {
                DB.db.Add(entity);
            }
            else
            {
                throw new ArgumentException($"Entity  not found.");
            }
        }
        public T RetrieveById(Func<T, bool> predicate)
        {
            try
            {
                return DB.db.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving data: {ex.Message}");
                return default(T);
            }
        }
    }
}
