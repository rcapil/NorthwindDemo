using NorthwindProducts.Core.Model;
using System.Collections.Generic;

namespace NorthwindProducts.Core.Interfaces.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
    }
}
