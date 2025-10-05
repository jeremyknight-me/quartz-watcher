namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerTriggersResumedEvent : IQuartzEvent
{
    private SchedulerTriggersResumedEvent()
    {
    }

    public required string? TriggerGroup { get; init; }

    public static SchedulerTriggersResumedEvent Create(string? triggerGroup)
        => new()
        {
            TriggerGroup = triggerGroup
        };
}
