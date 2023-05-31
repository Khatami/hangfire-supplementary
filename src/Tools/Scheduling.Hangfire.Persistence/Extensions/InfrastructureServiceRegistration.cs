using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scheduling.Domain.Domain.Jobs;
using Scheduling.Infrastructure.Persistence.JobItems;
using Scheduling.Infrastructure.Persistence.Jobs;

namespace Scheduling.Infrastructure.Persistence.Extensions
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection RegisterInfrastructureServices
			(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<HangfireDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionString")));

			services.AddScoped<IJobRepository, JobRepository>();
			services.AddScoped<IJobItemRepository, JobItemRepository>();

			return services;
		}
	}
}
