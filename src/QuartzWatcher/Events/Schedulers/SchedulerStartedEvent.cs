namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerStartedEvent : IQuartzEvent
{
    public DateTimeOffset EventTimeUtc { get; init; } = DateTimeOffset.UtcNow;
}

