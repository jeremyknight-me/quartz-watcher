namespace QuartzWatcher.Events.Jobs;

/// <summary>
/// Represents an event that occurs when a Quartz job execution is vetoed.
/// </summary>
public sealed record JobExecutionVetoedEvent : IQuartzEvent
{
    private JobExecutionVetoedEvent()
    {
    }

    /// <summary>
    /// Gets contextual information about the job execution.
    /// </summary>
    public required ContextInfo Context { get; init; }

    /// <summary>
    /// Creates a new <see cref="JobExecutionVetoedEvent"/> instance from the specified execution context.
    /// </summary>
    /// <param name="context">The job execution context.</param>
    /// <returns>A new <see cref="JobExecutionVetoedEvent"/> instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="context"/> is null.</exception>
    public static JobExecutionVetoedEvent Create(IJobExecutionContext context)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        return new JobExecutionVetoedEvent
        {
            Context = ContextInfo.Create(context)
        };
    }
}
