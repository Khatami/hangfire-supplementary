using Scheduling.Domain.Domain.Jobs;
using System.Linq.Expressions;

namespace Scheduling.Application.Jobs.IServices
{
    public interface IJobService
    {
		Task<Job> CreateJobAsync(long id, long jobType, string jobTypeTitle, string Name, string payload, Expression<Action> methodCall);
	}
}