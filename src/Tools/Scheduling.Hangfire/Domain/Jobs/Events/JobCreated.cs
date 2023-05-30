namespace Scheduling.Hangfire.Domain.Jobs.Events
{
	public record JobCreated(long Id, string Name, long JobType);
}
