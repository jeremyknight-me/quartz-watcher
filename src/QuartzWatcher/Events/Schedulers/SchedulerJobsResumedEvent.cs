namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Represents an event that occurs when multiple jobs in a group are resumed in the scheduler.
/// </summary>
public sealed record SchedulerJobsResumedEvent : IQuartzEvent
{
    private SchedulerJobsResumedEvent()
    {
    }

    /// <summary>
    /// Gets the name of the job group that was resumed.
    /// </summary>
    public required string JobGroup { get; init; }

    /// <summary>
    /// Creates a new instance of <see cref="SchedulerJobsResumedEvent"/> with the specified job group.
    /// </summary>
    /// <param name="jobGroup">The name of the job group that was resumed.</param>
    /// <returns>A new <see cref="SchedulerJobsResumedEvent"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="jobGroup"/> is null, empty, or whitespace.</exception>
    public static SchedulerJobsResumedEvent Create(string jobGroup)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(jobGroup, nameof(jobGroup));
        return new()
        {
            JobGroup = jobGroup
        };
    }
}

