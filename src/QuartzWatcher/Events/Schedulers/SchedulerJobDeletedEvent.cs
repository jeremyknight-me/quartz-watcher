namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Event raised when a job is deleted from the scheduler.
/// </summary>
public sealed record SchedulerJobDeletedEvent : IQuartzEvent
{
    private SchedulerJobDeletedEvent()
    {
    }

    /// <summary>
    /// Gets the name of the deleted job.
    /// </summary>
    public required string JobName { get; init; }

    /// <summary>
    /// Gets the group of the deleted job.
    /// </summary>
    public required string JobGroup { get; init; }

    /// <summary>
    /// Creates a new <see cref="SchedulerJobDeletedEvent"/> from a job key.
    /// </summary>
    /// <param name="jobKey">The key identifying the deleted job.</param>
    /// <returns>A new event instance.</returns>
    public static SchedulerJobDeletedEvent Create(JobKey jobKey)
    {
        ArgumentNullException.ThrowIfNull(jobKey, nameof(jobKey));
        return new()
        {
            JobName = jobKey.Name,
            JobGroup = jobKey.Group
        };
    }
}

