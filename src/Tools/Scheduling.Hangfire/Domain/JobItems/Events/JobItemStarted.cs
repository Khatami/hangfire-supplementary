namespace Scheduling.Hangfire.Domain.Domain.JobItems.Events
{
	public record JobItemStarted(long Id, DateTimeOffset StartedOn);
}
