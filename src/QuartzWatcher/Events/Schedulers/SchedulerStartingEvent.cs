namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerStartingEvent : IQuartzEvent
{
    public DateTimeOffset EventTimeUtc { get; init; } = DateTimeOffset.UtcNow;
}
