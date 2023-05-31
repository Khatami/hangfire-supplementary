using Scheduling.Domain.Domain.Jobs;

namespace Scheduling.Application.Jobs.IServices
{
    public interface IJobService
    {
		Task<Job> CreateJob(long id, long jobType, string Name, string payload);
	}
}