namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerTriggersPausedEvent : IQuartzEvent
{
    private SchedulerTriggersPausedEvent()
    {
    }

    public required string? TriggerGroup { get; init; }

    public static SchedulerTriggersPausedEvent Create(string? triggerGroup)
        => new()
        {
            TriggerGroup = triggerGroup
        };
}

