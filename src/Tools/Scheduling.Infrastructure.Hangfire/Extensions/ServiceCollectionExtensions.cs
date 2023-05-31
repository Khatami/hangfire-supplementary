using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.DependencyInjection;

namespace Scheduling.Infrastructure.Hangfire.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddHangfireScheduleServices(this IServiceCollection services,
		string sqlServerConnectionString,
		string schema)
	{
		services.AddHangfire(config => config
			.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
			.UseSimpleAssemblyNameTypeSerializer()
			.UseSqlServerStorage(sqlServerConnectionString, new SqlServerStorageOptions
			{
				CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
				SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
				QueuePollInterval = TimeSpan.Zero,
				UseRecommendedIsolationLevel = true,
				DisableGlobalLocks = true,
				SchemaName = schema + "_hangfire",
			}));

		// Add the processing server as IHostedService
		services.AddHangfireServer();
	}
}