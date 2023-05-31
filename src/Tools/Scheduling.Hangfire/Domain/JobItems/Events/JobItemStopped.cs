namespace Scheduling.Domain.Domain.JobItems.Events
{
	public record JobItemStopped(long Id, DateTimeOffset StoppedOn);
}
