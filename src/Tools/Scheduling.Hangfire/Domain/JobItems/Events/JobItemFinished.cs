using Scheduling.Hangfire.Domain.Domain.JobItems.Enums;

namespace Scheduling.Hangfire.Domain.Domain.JobItems.Events
{
	public record JobItemFinished(long Id, JobItemState JobItemState, string OutputList, DateTimeOffset FinishedOn);
}
