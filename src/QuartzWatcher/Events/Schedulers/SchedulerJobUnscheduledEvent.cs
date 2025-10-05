namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerJobUnscheduledEvent : IQuartzEvent
{
    private SchedulerJobUnscheduledEvent()
    {
    }

    public required string TriggerName { get; init; }
    public required string TriggerGroup { get; init; }

    public static SchedulerJobUnscheduledEvent Create(TriggerKey triggerKey)
        => new()
        {
            TriggerName = triggerKey.Name,
            TriggerGroup = triggerKey.Group
        };
}

