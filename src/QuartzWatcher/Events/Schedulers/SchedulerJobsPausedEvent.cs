namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerJobsPausedEvent : IQuartzEvent
{
    private SchedulerJobsPausedEvent()
    {
    }

    // todo: review null = all job groups paused
    public required string? JobGroup { get; init; }

    public static SchedulerJobsPausedEvent Create(string? jobGroup)
        => new()
        {
            JobGroup = jobGroup
        };
}
