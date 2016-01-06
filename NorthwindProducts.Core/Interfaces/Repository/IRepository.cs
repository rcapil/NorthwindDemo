using System;
using System.Linq;

namespace NorthwindProducts.Core.Interfaces.Repository
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> GetAll();
        IQueryable<T> All { get; }
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Upsert(T entity, Func<T, bool> insertExpression);
        void Save();
    }
}
