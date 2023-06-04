using Scheduling.Application.Jobs.IServices;
using Scheduling.Domain.Domain.Jobs;
using System.Linq.Expressions;

namespace Scheduling.Application.Jobs.Services
{
	public class JobService : IJobService
	{
		private ISchedulingService _schedulingService;

		public JobService(ISchedulingService schedulingService)
		{
			_schedulingService = schedulingService;
		}

		public async Task<Job> CreateJobAsync<T>(long id, 
			long jobType,
			string name, 
			Expression<Action<T>> methodCall, 
			string payload)
		{
			string schedulerId = await _schedulingService.EnqueueAsync<T>(methodCall);

			return null!;
		}
	}
}
