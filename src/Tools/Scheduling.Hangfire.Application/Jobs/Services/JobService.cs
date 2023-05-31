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

		public async Task<Job> CreateJobAsync(
			long id, 
			long jobType, 
			string jobTypeTitle, 
			string Name, 
			string payload, 
			Expression<Action> methodCall)
		{
			await _schedulingService.EnqueueAsync(methodCall, jobTypeTitle);

			return null!;
		}
	}
}
