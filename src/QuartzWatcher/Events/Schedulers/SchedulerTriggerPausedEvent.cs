namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerTriggerPausedEvent : IQuartzEvent
{
    private SchedulerTriggerPausedEvent()
    {
    }

    public required string TriggerName { get; init; }
    public required string TriggerGroup { get; init; }

    public static SchedulerTriggerPausedEvent Create(TriggerKey triggerKey)
        => new()
        {
            TriggerName = triggerKey.Name,
            TriggerGroup = triggerKey.Group
        };
}

