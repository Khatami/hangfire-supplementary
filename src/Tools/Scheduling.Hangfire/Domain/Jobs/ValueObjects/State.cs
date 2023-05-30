using Scheduling.Hangfire.Domain.Jobs.Enums;

namespace Scheduling.Hangfire.Domain.Jobs.ValueObjects
{
    public record State(JobState JobState);
}
