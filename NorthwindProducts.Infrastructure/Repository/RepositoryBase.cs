using NorthwindProducts.Core.Interfaces.Repository;
using System;
using System.Data.Entity;
using System.Linq;

namespace NorthwindProducts.Infrastructure.Repository
{
    public class RepositoryBase<T> : BaseGenericRepository, IRepository<T> where T : class
    {
        public RepositoryBase(DbContext context)
        {
            _entities = context;
        }

        public override Type Type
        {
            get { return typeof(T); }
        }

        private readonly DbContext _entities;

        public virtual DbContext GetContext()
        {
            return _entities;
        }

        public virtual IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public virtual void Add(T entity)
        {

            _entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {

            _entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {

            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Upsert(T entity, Func<T, bool> insertExpression)
        {
            if (insertExpression.Invoke(entity))
            {
                Add(entity);
            }
            else
            {
                Edit(entity);
            }
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {

            if (!this._disposed)
                if (disposing)
                    _entities.Dispose();

            this._disposed = true;
        }

        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
