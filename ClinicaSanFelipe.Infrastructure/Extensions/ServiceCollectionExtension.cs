using ClinicaSanFelipe.Core.CustomEntities;
using ClinicaSanFelipe.Core.Interfaces.Repositories;
using ClinicaSanFelipe.Core.Interfaces.Services;
using ClinicaSanFelipe.Core.Services;
using ClinicaSanFelipe.Infrastructure.Data;
using ClinicaSanFelipe.Infrastructure.Interfaces;
using ClinicaSanFelipe.Infrastructure.Options;
using ClinicaSanFelipe.Infrastructure.Repositories;
using ClinicaSanFelipe.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaSanFelipe.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDBContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClinicaSanFelipeContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ClinicaSanFelipe"))
            );

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(options =>
            {
                var paginationSection = configuration.GetSection("Pagination");
                options.DefaultPageNumber = Convert.ToInt32(paginationSection["DefaultPageNumber"]);
                options.DefaultPageSize = Convert.ToInt32(paginationSection["DefaultPageSize"]);
            });

            services.Configure<PasswordOptions>(options =>
            {
                var passwordSection = configuration.GetSection("PasswordOptions");
                options.SaltSize = Convert.ToInt32(passwordSection["SaltSize"]);
                options.KeySize = Convert.ToInt32(passwordSection["KeySize"]);
                options.Iterations = Convert.ToInt32(passwordSection["Iterations"]);
            });

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<ICompraService, CompraService>();
            services.AddTransient<IVentaService, VentaService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPasswordService, PasswordService>();

            return services;
        }
    }
}
