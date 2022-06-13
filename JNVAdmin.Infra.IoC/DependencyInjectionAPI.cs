using JNVAdmin.Application.Interfaces;
using JNVAdmin.Application.Mappings;
using JNVAdmin.Application.Services;
using JNVAdmin.Domain.Interfaces;
using JNVAdmin.Infra.Data.Context;
using JNVAdmin.Infra.Data.Identity;
using JNVAdmin.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JNVAdmin.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ISnackService, SnackService>();
            services.AddScoped<IScheduleService, ScheduleService>();

            services.AddScoped<ISnackRepository, SnackRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));           

            return services;
        }
    }
}
