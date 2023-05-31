namespace Scheduling.Domain.Domain.JobItems.Events
{
	public record JobItemStarted(long Id, DateTimeOffset StartedOn);
}
