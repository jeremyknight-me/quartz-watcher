namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Event raised when a job execution is interrupted.
/// </summary>
public sealed record SchedulerJobInterruptedEvent : IQuartzEvent
{
    private SchedulerJobInterruptedEvent()
    {
    }

    /// <summary>
    /// Gets the name of the interrupted job.
    /// </summary>
    public required string JobName { get; init; }

    /// <summary>
    /// Gets the group of the interrupted job.
    /// </summary>
    public required string JobGroup { get; init; }

    /// <summary>
    /// Creates a new <see cref="SchedulerJobInterruptedEvent"/> from a job key.
    /// </summary>
    /// <param name="jobKey">The key identifying the interrupted job.</param>
    /// <returns>A new event instance.</returns>
    public static SchedulerJobInterruptedEvent Create(JobKey jobKey)
    {
        ArgumentNullException.ThrowIfNull(jobKey, nameof(jobKey));
        return new()
        {
            JobName = jobKey.Name,
            JobGroup = jobKey.Group
        };
    }
}

