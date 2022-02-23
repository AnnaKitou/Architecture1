using MyDatabase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceGeneric.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext Context;
        private DbSet<T> table = null;

        public GenericRepository(ApplicationDbContext context)
        {
            Context = context;
            table = context.Set<T>();
        }

        public void Add(T entity)
        {
            table.Add(entity);
            Context.SaveChanges();
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            var entity = table.Find(id);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            var entities = table.ToList();
            return entities;
        }

        public void Remove(int id)
        {
            var entity = table.Find(id);
            if (entity == null)
            {
                throw new ArgumentException("This Entity doe not exist");
            }
            table.Remove(entity);
            Context.SaveChanges();
        }
    }
}
