namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Event raised when the scheduler enters standby mode.
/// </summary>
public sealed record SchedulerInStandbyModeEvent : IQuartzEvent
{
    /// <summary>
    /// Gets the UTC time when the event occurred.
    /// </summary>
    public DateTimeOffset EventTimeUtc { get; init; } = DateTimeOffset.UtcNow;
}

