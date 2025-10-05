namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerJobPausedEvent : IQuartzEvent
{
    private SchedulerJobPausedEvent()
    {
    }

    public required string JobName { get; init; }
    public required string JobGroup { get; init; }

    public static SchedulerJobPausedEvent Create(JobKey jobKey)
        => new()
        {
            JobName = jobKey.Name,
            JobGroup = jobKey.Group
        };
}

