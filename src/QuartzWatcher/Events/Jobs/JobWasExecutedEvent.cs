namespace QuartzWatcher.Events.Jobs;

/// <summary>
/// Represents an event that occurs after a Quartz job has been executed.
/// </summary>
public sealed record JobWasExecutedEvent : IQuartzEvent
{
    private JobWasExecutedEvent()
    {
    }

    /// <summary>
    /// Gets contextual information about the job execution.
    /// </summary>
    public required ContextInfo Context { get; init; }

    /// <summary>
    /// Gets a value indicating whether the job execution resulted in an exception.
    /// </summary>
    public bool HasException => Exception is not null;

    /// <summary>
    /// Gets the exception thrown during job execution, if any.
    /// </summary>
    public required JobExecutionException? Exception { get; init; }

    /// <summary>
    /// Creates a new <see cref="JobWasExecutedEvent"/> instance from the specified execution context and exception.
    /// </summary>
    /// <param name="context">The job execution context.</param>
    /// <param name="jobException">The exception thrown during job execution, if any.</param>
    /// <returns>A new <see cref="JobWasExecutedEvent"/> instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="context"/> is null.</exception>
    public static JobWasExecutedEvent Create(IJobExecutionContext context, JobExecutionException? jobException)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        return new JobWasExecutedEvent
        {
            Context = ContextInfo.Create(context),
            Exception = jobException
        };
    }
}
