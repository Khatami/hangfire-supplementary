using Hangfire;
using Scheduling.Application;
using System.Linq.Expressions;

namespace Scheduling.Infrastructure.Hangfire
{
	public class SchedulingService : ISchedulingService
	{
		public async Task<string> EnqueueAsync<T>(Expression<Action<T>> methodCall)
		{
			return BackgroundJob.Enqueue<T>(methodCall);
		}
	}
}
