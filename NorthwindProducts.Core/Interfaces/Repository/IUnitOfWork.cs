using System;

namespace NorthwindProducts.Core.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        void SaveChanges();
    }
}
