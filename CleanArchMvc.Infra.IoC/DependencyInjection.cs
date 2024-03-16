using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services,IConfiguration configuration)
        {
             SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(
                configuration.GetConnectionString("DefaultConnection"),b =>b.MigrationsAssembly(typeof(ApplicationDbContext)
                .Assembly.FullName)
                
            ));
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();

            SQLitePCL.Batteries.Init();
            
            return services;
        }

    }
}