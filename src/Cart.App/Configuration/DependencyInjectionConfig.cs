using Cart.Business.interfaces;
using Cart.Business.interfaces.Notifications;
using Cart.Business.interfaces.Services;
using Cart.Business.Interfaces;
using Cart.Business.Interfaces.Services;
using Cart.Business.Models;
using Cart.Business.Notifications;
using Cart.Business.Services;
using Cart.Data.Context;
using Cart.Data.Repository;
using Cart.Data.Services;

namespace Cart.App.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencyConfig(this IServiceCollection services)
        {

            services.AddScoped<CartDbContext>();
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IRepository<Address>, AddresRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();    

            services.AddScoped<ISupplierServices, SupplierServices>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}
