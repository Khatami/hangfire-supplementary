using Microsoft.Extensions.DependencyInjection;
using Scheduling.Application.Jobs.IServices;
using Scheduling.Application.Jobs.Services;

namespace Scheduling.Application
{
	public static class ApplicationServiceRegistration
	{
		public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IJobService, JobService>();

			return services;
		}
	}
}
