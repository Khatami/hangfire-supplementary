namespace Scheduling.Domain.Domain.Jobs.Events
{
	public record JobCreated(long Id, string Name, long JobType);
}
