namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Represents an event that is raised when a job is resumed.
/// </summary>
public sealed record SchedulerJobResumedEvent : IQuartzEvent
{
    private SchedulerJobResumedEvent()
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
    /// Creates a new instance of <see cref="SchedulerJobResumedEvent"/>.
    /// </summary>
    /// <param name="jobKey">The job key.</param>
    /// <returns>A new <see cref="SchedulerJobResumedEvent"/> instance.</returns>
    public static SchedulerJobResumedEvent Create(JobKey jobKey)
    {
        ArgumentNullException.ThrowIfNull(jobKey, nameof(jobKey));
        return new()
        {
            JobName = jobKey.Name,
            JobGroup = jobKey.Group
        };
    }
}

