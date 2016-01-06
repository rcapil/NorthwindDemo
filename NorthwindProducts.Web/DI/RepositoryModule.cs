using Autofac;
using NorthwindProducts.Core.Interfaces.Repository;
using NorthwindProducts.Infrastructure;
using NorthwindProducts.Infrastructure.Data;
using NorthwindProducts.Infrastructure.Repository;
using System.Data.Entity;

namespace NorthwindProducts.Web.DI
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(NorthwindEntities)).As(typeof(DbContext));
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork));
            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepository<>)).UsingConstructor(typeof(DbContext));
        }
    }
}