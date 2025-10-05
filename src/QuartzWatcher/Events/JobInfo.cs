namespace QuartzWatcher.Events;

/// <summary>
/// Contains information about a Quartz job.
/// </summary>
public sealed record JobInfo
{
    private JobInfo()
    {
    }

    /// <summary>
    /// Indicates whether concurrent execution is disallowed for the job.
    /// </summary>
    public required bool ConcurrentExecutionDisallowed { get; init; }

    /// <summary>
    /// The data map associated with the job.
    /// </summary>
    public required IReadOnlyDictionary<string, object> DataMap { get; init; }

    /// <summary>
    /// The description of the job, if any.
    /// </summary>
    public required string? Description { get; init; }

    /// <summary>
    /// Indicates whether the job is durable.
    /// </summary>
    public required bool Durable { get; init; }

    /// <summary>
    /// The group to which the job belongs.
    /// </summary>
    public required string Group { get; init; }

    /// <summary>
    /// The name of the job.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Indicates whether job data should be persisted after execution.
    /// </summary>
    public required bool PersistJobDataAfterExecution { get; init; }

    /// <summary>
    /// Indicates whether the job requests recovery.
    /// </summary>
    public required bool RequestsRecovery { get; init; }

    /// <summary>
    /// The full type name of the job.
    /// </summary>
    public required string TypeName { get; init; }

    /// <summary>
    /// Creates a new instance of <see cref="JobInfo"/> from a job detail.
    /// </summary>
    /// <param name="job">The job detail.</param>
    /// <returns>A new <see cref="JobInfo"/> instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="job"/> is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the job type name is null.</exception>
    public static JobInfo Create(IJobDetail job)
    {
        ArgumentNullException.ThrowIfNull(job, nameof(job));
        return new()
        {
            ConcurrentExecutionDisallowed = job.ConcurrentExecutionDisallowed,
            DataMap = job.JobDataMap.AsReadOnly(),
            Description = job.Description,
            Durable = job.Durable,
            Group = job.Key.Group,
            Name = job.Key.Name,
            PersistJobDataAfterExecution = job.PersistJobDataAfterExecution,
            RequestsRecovery = job.RequestsRecovery,
            TypeName = job.JobType.FullName
                ?? throw new InvalidOperationException("Job type name cannot be null.")
        };
    }
}
