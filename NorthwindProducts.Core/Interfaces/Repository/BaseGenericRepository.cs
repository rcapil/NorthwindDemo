using System;

namespace NorthwindProducts.Core.Interfaces.Repository
{
    public abstract class BaseGenericRepository
    {
        public abstract Type Type { get; }
    }
}
