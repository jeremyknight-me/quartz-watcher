namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerInStandbyModeEvent : IQuartzEvent
{
    public DateTimeOffset EventTimeUtc { get; init; } = DateTimeOffset.UtcNow;
}

