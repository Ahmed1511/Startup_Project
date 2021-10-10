using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastracture.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private DbSet<T> table = null;
        public GenericRepository(DataContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }
        public void Delete(object id)
        {
            T existing = GetbyId(id);
            table.Remove(existing);
        }

        public IEnumerable<T> Getall()
        {
            return table.ToList();
        }

        public T GetbyId(object id)
        {
            return table.Find(id);
        }

        public void Insert(T entity)
        {
            table.Add(entity);
        }

        public void Update(T entity)
        {
            table.Update(entity);
        }


    }
}
