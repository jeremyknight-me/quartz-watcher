namespace QuartzWatcher.Events.Triggers;

/// <summary>
/// Represents an event that occurs when a Quartz trigger is misfired.
/// </summary>
public sealed record TriggerMisfiredEvent : IQuartzEvent
{
    private TriggerMisfiredEvent()
    {
    }

    /// <summary>
    /// Gets information about the misfired trigger.
    /// </summary>
    public required TriggerInfo Trigger { get; init; }

    /// <summary>
    /// Creates a new <see cref="TriggerMisfiredEvent"/> instance from the specified trigger.
    /// </summary>
    /// <param name="trigger">The misfired trigger.</param>
    /// <returns>A new <see cref="TriggerMisfiredEvent"/> instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="trigger"/> is null.</exception>
    public static TriggerMisfiredEvent Create(ITrigger trigger)
    {
        ArgumentNullException.ThrowIfNull(trigger, nameof(trigger));
        return new()
        {
            Trigger = TriggerInfo.Create(trigger)
        };
    }
}
