namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Represents an event raised when the scheduler is starting.
/// </summary>
public sealed record SchedulerStartingEvent : IQuartzEvent
{
    /// <summary>
    /// Gets the UTC timestamp when the event occurred.
    /// </summary>
    public DateTimeOffset EventTimeUtc { get; init; } = DateTimeOffset.UtcNow;
}
