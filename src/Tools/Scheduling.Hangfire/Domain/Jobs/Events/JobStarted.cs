namespace Scheduling.Domain.Domain.Jobs.Events
{
	public record JobStarted(long Id, DateTimeOffset StartedOn);
}
