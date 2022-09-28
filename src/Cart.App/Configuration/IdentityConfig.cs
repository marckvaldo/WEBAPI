using Cart.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Cart.App.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection addIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            string stringConexao = configuration.GetConnectionString("conexaoMySql");
            services.AddDbContext<CartDbContext>(options =>
            {
                options.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
            });

            return services;
        }
    }
}
