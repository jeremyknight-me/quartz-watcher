namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Event raised when a Quartz scheduler is shutting down.
/// </summary>
 public sealed record SchedulerShuttingDownEvent : IQuartzEvent
{
    /// <summary>
    /// Gets the UTC time when the event occurred.
    /// </summary>
    public DateTimeOffset EventTimeUtc { get; init; } = DateTimeOffset.UtcNow;
}
