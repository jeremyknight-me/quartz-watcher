namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Event raised when a trigger is paused.
/// </summary>
public sealed record SchedulerTriggerPausedEvent : IQuartzEvent
{
    private SchedulerTriggerPausedEvent()
    {
    }

    /// <summary>
    /// Gets the name of the paused trigger.
    /// </summary>
    public required string TriggerName { get; init; }

    /// <summary>
    /// Gets the group of the paused trigger.
    /// </summary>
    public required string TriggerGroup { get; init; }

    /// <summary>
    /// Creates a new <see cref="SchedulerTriggerPausedEvent"/> from a trigger key.
    /// </summary>
    /// <param name="triggerKey">The key identifying the paused trigger.</param>
    /// <returns>A new event instance.</returns>
    public static SchedulerTriggerPausedEvent Create(TriggerKey triggerKey)
    {
        ArgumentNullException.ThrowIfNull(triggerKey, nameof(triggerKey));
        return new()
        {
            TriggerName = triggerKey.Name,
            TriggerGroup = triggerKey.Group
        };
    }
}

