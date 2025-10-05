namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerJobResumedEvent : IQuartzEvent
{
    private SchedulerJobResumedEvent()
    {
    }

    public required string JobName { get; init; }
    public required string JobGroup { get; init; }

    public static SchedulerJobResumedEvent Create(JobKey jobKey)
        => new()
        {
            JobName = jobKey.Name,
            JobGroup = jobKey.Group
        };
}

