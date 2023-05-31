namespace Scheduling.Hangfire.Domain.Domain.JobItems.Enums
{
	public enum JobItemState
	{
		Queued,
		InProgress,
		Stopped,
		Success,
		Failed
	}
}
