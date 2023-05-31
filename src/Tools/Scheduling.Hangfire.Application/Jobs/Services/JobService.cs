using Scheduling.Application.Jobs.IServices;
using Scheduling.Domain.Domain.Jobs;

namespace Scheduling.Application.Jobs.Services
{
    public class JobService : IJobService
	{
		public async Task<Job> CreateJob(long id, long jobType, string Name, string payload)
		{
			
		}
	}
}
