using NorthwindProducts.Core.Interfaces.Repository;
using NorthwindProducts.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProducts.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly Dictionary<Type, BaseGenericRepository> _dictionary;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _context.ChangeTracker.DetectChanges();
            _context.Configuration.AutoDetectChangesEnabled = true;
            _dictionary = new Dictionary<Type, BaseGenericRepository>();
        }

        private void Put<T>(RepositoryBase<T> item) where T : class
        {
            _dictionary[typeof(T)] = item;
        }

        private RepositoryBase<T> Get<T>() where T : class
        {
            if (_dictionary.ContainsKey(typeof(T)))
            {
                return _dictionary[typeof(T)] as RepositoryBase<T>;
            }

            var efr = new RepositoryBase<T>(_context);
            Put(efr);

            return efr;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return Get<T>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
