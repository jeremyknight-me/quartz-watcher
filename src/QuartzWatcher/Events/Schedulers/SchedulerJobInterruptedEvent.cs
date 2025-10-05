namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerJobInterruptedEvent : IQuartzEvent
{
    private SchedulerJobInterruptedEvent()
    {
    }

    public required string JobName { get; init; }
    public required string JobGroup { get; init; }

    public static SchedulerJobInterruptedEvent Create(JobKey jobKey)
        => new()
        {
            JobName = jobKey.Name,
            JobGroup = jobKey.Group
        };
}

