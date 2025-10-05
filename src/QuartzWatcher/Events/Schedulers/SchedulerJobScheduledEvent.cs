namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Represents an event raised when a job is scheduled in the Quartz scheduler.
/// </summary>
public sealed record SchedulerJobScheduledEvent : IQuartzEvent
{
    private SchedulerJobScheduledEvent()
    {
    }

    /// <summary>
    /// Gets the trigger information for the scheduled job.
    /// </summary>
    public required TriggerInfo Trigger { get; init; }

    /// <summary>
    /// Creates a new instance of <see cref="SchedulerJobScheduledEvent"/> from the specified trigger.
    /// </summary>
    /// <param name="trigger">The Quartz trigger to create the event from.</param>
    /// <returns>A new instance of <see cref="SchedulerJobScheduledEvent"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="trigger"/> is null.</exception>
    public static SchedulerJobScheduledEvent Create(ITrigger trigger)
    {
        ArgumentNullException.ThrowIfNull(trigger, nameof(trigger));
        return new()
        {
            Trigger = TriggerInfo.Create(trigger)
        };
    }
}

