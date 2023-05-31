using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Scheduling.Hangfire.Persistence.Extensions
{
	public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection RegisterInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HangfireDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionString")));

            return services;
        }
    }
}
