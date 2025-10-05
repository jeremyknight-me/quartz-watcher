namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Represents an event that is raised when scheduler triggers are resumed.
/// </summary>
public sealed record SchedulerTriggerResumedEvent : IQuartzEvent
{
    /// <summary>
    /// Gets the trigger group that was resumed, or null if all triggers were resumed.
    /// </summary>
    private SchedulerTriggerResumedEvent()
    {
    }

    /// <summary>
    /// Gets the name of the resumed trigger.
    /// </summary>
    public required string TriggerName { get; init; }

    /// <summary>
    /// Gets the group of the resumed trigger.
    /// </summary>
    public required string TriggerGroup { get; init; }

    /// <summary>
    /// Creates a new instance of <see cref="SchedulerTriggersResumedEvent"/>.
    /// </summary>
    /// <param name="triggerGroup">The trigger group that was resumed, or null for all triggers.</param>
    /// <returns>A new <see cref="SchedulerTriggersResumedEvent"/> instance.</returns>
    public static SchedulerTriggerResumedEvent Create(TriggerKey triggerKey)
    {
        ArgumentNullException.ThrowIfNull(triggerKey, nameof(triggerKey));
        return new()
        {
            TriggerName = triggerKey.Name,
            TriggerGroup = triggerKey.Group
        };
    }
}

