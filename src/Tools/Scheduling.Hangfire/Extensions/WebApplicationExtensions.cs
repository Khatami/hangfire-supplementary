using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Scheduling.Hangfire.Extensions;

public static class WebApplicationExtensions
{
	public static void UseJobsDashboard(this WebApplication app, IConfiguration configuration)
	{
		app.UseHangfireDashboard("/jobs");
	}
}