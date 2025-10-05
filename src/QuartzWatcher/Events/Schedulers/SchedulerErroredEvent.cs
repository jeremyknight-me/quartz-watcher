namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Event raised when an error occurs in the scheduler.
/// </summary>
public sealed record SchedulerErroredEvent : IQuartzEvent
{
    private SchedulerErroredEvent()
    {
    }

    /// <summary>
    /// Gets the error message.
    /// </summary>
    public required string ErrorMessage { get; init; }

    /// <summary>
    /// Gets the scheduler exception that occurred.
    /// </summary>
    public required SchedulerException SchedulerException { get; init; }

    /// <summary>
    /// Creates a new <see cref="SchedulerErroredEvent"/> from an error message and exception.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="exception">The scheduler exception.</param>
    /// <returns>A new event instance.</returns>
    public static SchedulerErroredEvent Create(string message, SchedulerException exception)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        ArgumentNullException.ThrowIfNull(exception, nameof(exception));
        // todo: review serialization of exception
        return new()
        {
            ErrorMessage = message,
            SchedulerException = exception
        };
    }
}

