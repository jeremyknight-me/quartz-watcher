namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerTriggerFinalizedEvent : IQuartzEvent
{
    private SchedulerTriggerFinalizedEvent()
    {
    }

    public required TriggerInfo Trigger { get; init; }

    public static SchedulerTriggerFinalizedEvent Create(ITrigger trigger)
        => new()
        {
            Trigger = TriggerInfo.Create(trigger)
        };
}

