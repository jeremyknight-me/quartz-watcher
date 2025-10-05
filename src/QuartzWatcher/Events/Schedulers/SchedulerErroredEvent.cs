namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerErroredEvent : IQuartzEvent
{
    private SchedulerErroredEvent()
    {
    }

    public required string ErrorMessage { get; init; }
    public required SchedulerException SchedulerException { get; init; }

    // todo: review serialization of exception
    public static SchedulerErroredEvent Create(string message, SchedulerException exception)
        => new()
        {
            ErrorMessage = message,
            SchedulerException = exception
        };
}

