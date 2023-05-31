using Scheduling.Domain.Domain.Jobs;

namespace Scheduling.Application.Jobs.IServices
{
    public interface IJobService
    {
        Task<Job> CreateJob();
    }
}