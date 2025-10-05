namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Represents an event that is raised when a job is paused.
/// </summary>
public sealed record SchedulerJobPausedEvent : IQuartzEvent
{
    private SchedulerJobPausedEvent()
    {
    }

    /// <summary>
    /// Gets the name of the job.
    /// </summary>
    public required string JobName { get; init; }

    /// <summary>
    /// Gets the group of the job.
    /// </summary>
    public required string JobGroup { get; init; }

    /// <summary>
    /// Creates a new instance of <see cref="SchedulerJobPausedEvent"/>.
    /// </summary>
    /// <param name="jobKey">The job key.</param>
    /// <returns>A new <see cref="SchedulerJobPausedEvent"/> instance.</returns>
    public static SchedulerJobPausedEvent Create(JobKey jobKey)
    {
        ArgumentNullException.ThrowIfNull(jobKey, nameof(jobKey));
        return new()
        {
            JobName = jobKey.Name,
            JobGroup = jobKey.Group
        };
    }
}

