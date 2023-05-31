namespace Scheduling.Hangfire.Domain.Domain.Jobs.Events
{
	public record JobStopped(long Id, DateTimeOffset StoppedOn);
}
