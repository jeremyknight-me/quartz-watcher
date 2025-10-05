namespace QuartzWatcher.Events.Triggers;

public sealed record TriggerFiredEvent : IQuartzEvent
{
    private TriggerFiredEvent()
    {
    }

    public required ContextInfo Context { get; init; }
    public required TriggerInfo Trigger { get; init; }

    public static TriggerFiredEvent Create(ITrigger trigger, IJobExecutionContext context)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        ArgumentNullException.ThrowIfNull(trigger, nameof(trigger));
        return new()
        {
            Context = ContextInfo.Create(context),
            Trigger = TriggerInfo.Create(trigger)
        };
    }
}
