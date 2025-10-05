namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerJobsPausedEvent : IQuartzEvent
{
    private SchedulerJobsPausedEvent()
    {
    }

    public required string JobGroup { get; init; }

    public static SchedulerJobsPausedEvent Create(string jobGroup)
        => new()
        {
            JobGroup = jobGroup
        };
}
