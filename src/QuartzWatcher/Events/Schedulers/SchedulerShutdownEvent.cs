namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerShutdownEvent : IQuartzEvent
{
    public DateTimeOffset EventTimeUtc { get; init; } = DateTimeOffset.UtcNow;
}

