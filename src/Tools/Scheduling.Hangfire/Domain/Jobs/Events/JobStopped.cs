namespace Scheduling.Domain.Domain.Jobs.Events
{
	public record JobStopped(long Id, DateTimeOffset StoppedOn);
}
