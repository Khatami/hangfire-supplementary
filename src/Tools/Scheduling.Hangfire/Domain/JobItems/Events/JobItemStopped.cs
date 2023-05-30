namespace Scheduling.Hangfire.Domain.JobItems.Events
{
    public record JobItemStopped(long Id, DateTimeOffset StoppedOn);
}
