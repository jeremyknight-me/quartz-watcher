namespace QuartzWatcher.Events.Jobs;

/// <summary>
/// Represents an event that occurs before a Quartz job is executed.
/// </summary>
public sealed record JobToBeExecutedEvent : IQuartzEvent
{
    private JobToBeExecutedEvent()
    {
    }

    /// <summary>
    /// Gets contextual information about the job execution.
    /// </summary>
    public required ContextInfo Context { get; init; }

    /// <summary>
    /// Creates a new <see cref="JobToBeExecutedEvent"/> instance from the specified execution context.
    /// </summary>
    /// <param name="context">The job execution context.</param>
    /// <returns>A new <see cref="JobToBeExecutedEvent"/> instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="context"/> is null.</exception>
    public static JobToBeExecutedEvent Create(IJobExecutionContext context)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        return new JobToBeExecutedEvent
        {
            Context = ContextInfo.Create(context)
        };
    }
}
