﻿namespace Scheduling.Hangfire.Domain.JobItems.Enums
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
