namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Event raised when a job is unscheduled from the scheduler.
/// </summary>
public sealed record SchedulerJobUnscheduledEvent : IQuartzEvent
{
    private SchedulerJobUnscheduledEvent()
    {
    }

    /// <summary>
    /// Gets the name of the unscheduled trigger.
    /// </summary>
    public required string TriggerName { get; init; }

    /// <summary>
    /// Gets the group of the unscheduled trigger.
    /// </summary>
    public required string TriggerGroup { get; init; }

    /// <summary>
    /// Creates a new <see cref="SchedulerJobUnscheduledEvent"/> from a trigger key.
    /// </summary>
    /// <param name="triggerKey">The key identifying the unscheduled trigger.</param>
    /// <returns>A new event instance.</returns>
    public static SchedulerJobUnscheduledEvent Create(TriggerKey triggerKey)
    {
        ArgumentNullException.ThrowIfNull(triggerKey, nameof(triggerKey));
        return new()
        {
            TriggerName = triggerKey.Name,
            TriggerGroup = triggerKey.Group
        };
    }
}

