namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Represents an event raised when the scheduler has shut down.
/// </summary>
public sealed record SchedulerShutdownEvent : IQuartzEvent
{
    /// <summary>
    /// Gets the UTC timestamp when the event occurred.
    /// </summary>
    public DateTimeOffset EventTimeUtc { get; init; } = DateTimeOffset.UtcNow;
}

