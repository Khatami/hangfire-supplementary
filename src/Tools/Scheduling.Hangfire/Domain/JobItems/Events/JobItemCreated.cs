namespace Scheduling.Domain.Domain.JobItems.Events
{
	public record JobItemCreated(long Id, long JobId, string Payload, long SchedulerId);
}
