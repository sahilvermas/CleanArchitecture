using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infrastructure.Hangfire.Repositories;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.Hangfire
{
    public static class ServiceRegistration
    {
        public static void AddHanfireInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(x =>
            {
                x.UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"));
            });

            services.AddScoped<IJobService, JobService>();

            services.AddHangfireServer();
        }
    }
}