namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerJobScheduledEvent : IQuartzEvent
{
    private SchedulerJobScheduledEvent()
    {
    }

    public required TriggerInfo Trigger { get; init; }

    public static SchedulerJobScheduledEvent Create(ITrigger trigger)
    {
        ArgumentNullException.ThrowIfNull(trigger, nameof(trigger));
        return new()
        {
            Trigger = TriggerInfo.Create(trigger)
        };
    }
}

