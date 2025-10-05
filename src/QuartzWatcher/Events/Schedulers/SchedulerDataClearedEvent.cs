namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerDataClearedEvent : IQuartzEvent
{
    public DateTimeOffset EventTimeUtc { get; init; } = DateTimeOffset.UtcNow;
}

