namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Represents an event raised when the scheduler has started.
/// </summary>
public sealed record SchedulerStartedEvent : IQuartzEvent
{
    /// <summary>
    /// Gets the UTC timestamp when the event occurred.
    /// </summary>
    public DateTimeOffset EventTimeUtc { get; init; } = DateTimeOffset.UtcNow;
}

