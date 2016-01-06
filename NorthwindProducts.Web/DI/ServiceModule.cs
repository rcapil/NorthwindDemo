using Autofac;
using NorthwindProducts.Core.Interfaces.Service;
using NorthwindProducts.Infrastructure.Services;

namespace NorthwindProducts.Web.DI
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(ProductService)).As(typeof(IProductService));
        }
    }
}