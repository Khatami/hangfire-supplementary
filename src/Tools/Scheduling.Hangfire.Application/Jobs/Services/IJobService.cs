using Scheduling.Domain.Domain.Jobs;

namespace Scheduling.Application.Jobs.Services
{
	public interface IJobService
	{
		Task<Job> CreateJob();
	}
}