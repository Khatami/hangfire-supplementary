using Hangfire;
using Scheduling.Application;
using System.Linq.Expressions;

namespace Scheduling.Infrastructure.Hangfire
{
	public class SchedulingService : ISchedulingService
	{
		public async Task EnqueueAsync(Expression<Action> methodCall, string queueName)
		{
			string result = BackgroundJob.Enqueue(queueName, methodCall);
		}
	}
}
