namespace QuartzWatcher.Events.Triggers;

/// <summary>
/// Event raised when a trigger is fired.
/// </summary>
public sealed record TriggerFiredEvent : IQuartzEvent
{
    private TriggerFiredEvent()
    {
    }

    /// <summary>
    /// Gets the execution context information for the fired trigger.
    /// </summary>
    public required ContextInfo Context { get; init; }

    /// <summary>
    /// Gets the trigger information for the fired trigger.
    /// </summary>
    public required TriggerInfo Trigger { get; init; }

    /// <summary>
    /// Creates a new <see cref="TriggerFiredEvent"/> from a trigger and execution context.
    /// </summary>
    /// <param name="trigger">The trigger that fired.</param>
    /// <param name="context">The job execution context.</param>
    /// <returns>A new event instance.</returns>
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
