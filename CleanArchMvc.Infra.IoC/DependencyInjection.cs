using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Account;
using CleanArchMvc.Domain.Identity;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Identity;
using CleanArchMvc.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(
                configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext)
                .Assembly.FullName)

            ));
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(DomainTODTOMappingProfile));
            var myhandlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");
            services.AddMediatR(myhandlers);
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");

            using (var serviceScope = services.BuildServiceProvider().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }

            return services;
        }

    }
}