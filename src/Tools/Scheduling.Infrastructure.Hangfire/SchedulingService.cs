using Hangfire;
using Scheduling.Application;
using System.Linq.Expressions;

namespace Scheduling.Infrastructure.Hangfire
{
	public class SchedulingService : ISchedulingService
	{
		public async Task EnqueueAsync<T>(Expression<Action<T>> methodCall, string queueName)
		{
			string result = BackgroundJob.Enqueue<T>(queueName, methodCall);
		}
	}
}
