namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerJobDeletedEvent : IQuartzEvent
{
    private SchedulerJobDeletedEvent()
    {
    }

    public required string JobName { get; init; }
    public required string JobGroup { get; init; }

    public static SchedulerJobDeletedEvent Create(JobKey jobKey)
        => new()
        {
            JobName = jobKey.Name,
            JobGroup = jobKey.Group
        };
}

