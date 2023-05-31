using Scheduling.Domain.Domain.JobItems.Enums;

namespace Scheduling.Domain.Domain.JobItems.Events
{
	public record JobItemFinished(long Id, JobItemState JobItemState, string OutputList, DateTimeOffset FinishedOn);
}
