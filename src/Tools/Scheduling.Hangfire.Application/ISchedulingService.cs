using System.Linq.Expressions;

namespace Scheduling.Application
{
	public interface ISchedulingService
	{
		Task EnqueueAsync<T>(Expression<Action<T>> methodCall, string queueName);
	}
}
