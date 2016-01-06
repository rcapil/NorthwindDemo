using NorthwindProducts.Core.Interfaces.Service;
using System.Collections.Generic;
using NorthwindProducts.Core.Model;
using EF = NorthwindProducts.Infrastructure.Data;
using NorthwindProducts.Core.Interfaces.Repository;
using System.Linq;

namespace NorthwindProducts.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<EF.Product> _productRepo;
        private readonly IRepository<EF.Supplier> _supplierRepo;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _productRepo = unitOfWork.GetRepository<EF.Product>();
            _supplierRepo = unitOfWork.GetRepository<EF.Supplier>();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = new List<EF.Product>();

            products = _productRepo.GetAll().ToList();

            return products.Select(p => new Product
            {
                ProductName = p.ProductName,
                QuantityPerUnit = p.QuantityPerUnit,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                UnitsOnOrder = p.UnitsOnOrder,
                ReorderLevel = p.ReorderLevel,
                Discontinued = p.Discontinued,
                Supplier = new Supplier
                {
                    CompanyName = p.Supplier.CompanyName,
                    ContactName = p.Supplier.ContactName,
                    ContactTitle = p.Supplier.ContactTitle,
                    Address = p.Supplier.Address,
                    City = p.Supplier.City,
                    Region = p.Supplier.Region,
                    PostalCode = p.Supplier.PostalCode,
                    Country = p.Supplier.Country,
                    Phone = p.Supplier.Phone,
                    Fax = p.Supplier.Fax
                }
            }).ToList();
        }
    }
}
