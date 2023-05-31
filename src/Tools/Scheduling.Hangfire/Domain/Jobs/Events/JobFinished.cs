namespace Scheduling.Domain.Domain.Jobs.Events
{
	public record JobFinished(long Id, DateTimeOffset FinishedOn);
}
