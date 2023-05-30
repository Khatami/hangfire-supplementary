namespace Scheduling.Hangfire.Domain.Jobs.Events
{
	public record JobStopped(long Id, DateTimeOffset StoppedOn);
}
