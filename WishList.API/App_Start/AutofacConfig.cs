using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using BL.Services.Implementations;
using BL.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;

namespace WishList.API
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventListService>().As<IEventListService>().InstancePerRequest();
            builder.RegisterType<ProductListService>().As<IProductListService>().InstancePerRequest();
            builder.RegisterType<StoreService>().As<IStoreService>().InstancePerRequest();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerRequest();

            builder.RegisterType<EventListRepository>().As<IEventListRepository>().InstancePerRequest();
            builder.RegisterType<ProductListRepository>().As<IProductListRepository>().InstancePerRequest();
            builder.RegisterType<StoreRepository>().As<IStoreRepository>().InstancePerRequest();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}