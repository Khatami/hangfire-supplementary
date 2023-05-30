namespace Scheduling.Hangfire.Domain.JobItems.Events
{
    public record JobItemStarted(long Id, DateTimeOffset StartedOn);
}
