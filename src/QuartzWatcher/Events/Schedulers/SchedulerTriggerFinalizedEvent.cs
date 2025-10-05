namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Represents an event that is raised when a trigger is finalized.
/// </summary>
public sealed record SchedulerTriggerFinalizedEvent : IQuartzEvent
{
    private SchedulerTriggerFinalizedEvent()
    {
    }

    /// <summary>
    /// Gets the trigger information.
    /// </summary>
    public required TriggerInfo Trigger { get; init; }

    /// <summary>
    /// Creates a new instance of <see cref="SchedulerTriggerFinalizedEvent"/>.
    /// </summary>
    /// <param name="trigger">The trigger.</param>
    /// <returns>A new <see cref="SchedulerTriggerFinalizedEvent"/> instance.</returns>
    public static SchedulerTriggerFinalizedEvent Create(ITrigger trigger)
    {
        ArgumentNullException.ThrowIfNull(trigger, nameof(trigger));
        return new()
        {
            Trigger = TriggerInfo.Create(trigger)
        };
    }
}

