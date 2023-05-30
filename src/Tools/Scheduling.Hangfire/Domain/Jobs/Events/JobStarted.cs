namespace Scheduling.Hangfire.Domain.Jobs.Events
{
	public record JobStarted(long Id, DateTimeOffset StartedOn);
}
