using System.Linq.Expressions;

namespace Scheduling.Application
{
	public interface ISchedulingService
	{
		Task EnqueueAsync(Expression<Action> methodCall, string queueName);
	}
}
