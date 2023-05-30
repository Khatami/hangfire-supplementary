namespace Scheduling.Hangfire.Domain.Jobs.Events
{
	public record JobFinished(long Id, DateTimeOffset FinishedOn);
}
