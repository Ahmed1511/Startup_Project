using Core.Interfaces;
using Infrastracture.Repository;

namespace Infrastracture.UnitofWork
{
    public class UnitofWork<T> : IUnitofWork<T> where T : class
    {
        private readonly DataContext _context;
        private IGenericRepository<T> _entity;
        public UnitofWork(DataContext context)
        {
            _context = context;
        }
        public IGenericRepository<T> Entity { get { return _entity ?? (_entity = new GenericRepository<T>(_context)); } }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
