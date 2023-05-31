using System.Linq.Expressions;

namespace Scheduling.Application
{
	public interface ISchedulingService
	{
		Task<string> EnqueueAsync<T>(Expression<Action<T>> methodCall, string queueName);
	}
}
