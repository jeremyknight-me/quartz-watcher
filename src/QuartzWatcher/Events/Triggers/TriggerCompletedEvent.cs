namespace QuartzWatcher.Events.Triggers;

public sealed record class TriggerCompletedEvent : IQuartzEvent
{
    private TriggerCompletedEvent()
    {
    }

    public required ContextInfo Context { get; init; }
    public required string SchedulerInstruction { get; init; }
    public required TriggerInfo Trigger { get; init; }

    public static TriggerCompletedEvent Create(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction schedulerInstruction)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        ArgumentNullException.ThrowIfNull(trigger, nameof(trigger));
        return new()
        {
            Context = ContextInfo.Create(context),
            SchedulerInstruction = schedulerInstruction.ToString(),
            Trigger = TriggerInfo.Create(trigger)
        };
    }
}
