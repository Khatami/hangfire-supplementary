using Scheduling.Application.Jobs.Metadata;
using Scheduling.Domain.Domain.Jobs;
using System.Linq.Expressions;

namespace Scheduling.Application.Jobs.IServices
{
	public interface IJobService
    {
		Task<Job> CreateJobAsync<T>(long Id,
			long JobType,
			string Name,
			Expression<Action<T>> MethodCall,
			string Payload);
	}
}