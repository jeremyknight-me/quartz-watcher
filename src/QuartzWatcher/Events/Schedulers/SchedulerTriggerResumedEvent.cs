namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerTriggerResumedEvent : IQuartzEvent
{
    private SchedulerTriggerResumedEvent()
    {
    }

    public required string TriggerName { get; init; }
    public required string TriggerGroup { get; init; }

    public static SchedulerTriggerResumedEvent Create(TriggerKey triggerKey)
        => new()
        {
            TriggerName = triggerKey.Name,
            TriggerGroup = triggerKey.Group
        };
}

