using Scheduling.Hangfire.Domain.JobItems.Enums;

namespace Scheduling.Hangfire.Domain.JobItems.Events
{
	public record JobItemFinished(long Id, JobItemState JobItemState, string OutputList, DateTimeOffset FinishedOn);
}
