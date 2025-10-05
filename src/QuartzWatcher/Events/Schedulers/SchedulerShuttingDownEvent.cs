namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerShuttingDownEvent : IQuartzEvent
{
    public DateTimeOffset EventTimeUtc { get; init; } = DateTimeOffset.UtcNow;
}
