namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Event raised when scheduler data has been cleared.
/// </summary>
public sealed record SchedulerDataClearedEvent : IQuartzEvent
{
    /// <summary>
    /// Gets the UTC time when the event occurred.
    /// </summary>
    public DateTimeOffset EventTimeUtc { get; init; } = DateTimeOffset.UtcNow;
}

