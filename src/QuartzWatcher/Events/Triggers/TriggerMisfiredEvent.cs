namespace QuartzWatcher.Events.Triggers;

public sealed record TriggerMisfiredEvent : IQuartzEvent
{
    private TriggerMisfiredEvent()
    {
    }

    public required TriggerInfo Trigger { get; init; }

    public static TriggerMisfiredEvent Create(ITrigger trigger)
    {
        ArgumentNullException.ThrowIfNull(trigger, nameof(trigger));
        return new()
        {
            Trigger = TriggerInfo.Create(trigger)
        };
    }
}
