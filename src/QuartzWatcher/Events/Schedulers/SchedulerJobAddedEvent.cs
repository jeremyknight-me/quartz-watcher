namespace QuartzWatcher.Events.Schedulers;

/// <summary>
/// Represents an event that is raised when a job is added to the scheduler.
/// </summary>
 public sealed record SchedulerJobAddedEvent : IQuartzEvent
{
    private SchedulerJobAddedEvent()
    {
    }

    /// <summary>
    /// Gets the job description.
    /// </summary>
     public required string? Description { get; init; }

    /// <summary>
    /// Gets the job name.
    /// </summary>
     public required string? Name { get; init; }

    /// <summary>
    /// Gets the job group.
    /// </summary>
     public required string? Group { get; init; }

    /// <summary>
    /// Gets the full type name of the job.
    /// </summary>
     public required string? TypeFullName { get; init; }

   /// <summary>
   /// Gets the job data map.
   /// </summary>
     public required IReadOnlyDictionary<string, object> DataMap { get; init; }

   /// <summary>
   /// Gets a value indicating whether the job is durable.
   /// </summary>
     public required bool Durable { get; init; }

    /// <summary>
    /// Gets a value indicating whether job data should be persisted after execution.
    /// </summary>
     public required bool PersistJobDataAfterExecution { get; init; }

    /// <summary>
    /// Gets a value indicating whether concurrent execution is disallowed.
    /// </summary>
     public required bool ConcurrentExecutionDisallowed { get; init; }

    /// <summary>
    /// Gets a value indicating whether the job requests recovery.
    /// </summary>
     public required bool RequestsRecovery { get; init; }

    /// <summary>
    /// Creates a new instance of <see cref="SchedulerJobAddedEvent"/>.
    /// </summary>
    /// <param name="jobDetail">The job detail.</param>
    /// <returns>A new <see cref="SchedulerJobAddedEvent"/> instance.</returns>
    public static SchedulerJobAddedEvent Create(IJobDetail jobDetail)
    {
        ArgumentNullException.ThrowIfNull(jobDetail, nameof(jobDetail));
        return new()
        {
            Description = jobDetail.Description,
            Name = jobDetail.Key.Name,
            Group = jobDetail.Key.Group,
            TypeFullName = jobDetail.JobType.FullName,
            DataMap = jobDetail.JobDataMap.AsReadOnly(),
            Durable = jobDetail.Durable,
            PersistJobDataAfterExecution = jobDetail.PersistJobDataAfterExecution,
            ConcurrentExecutionDisallowed = jobDetail.ConcurrentExecutionDisallowed,
            RequestsRecovery = jobDetail.RequestsRecovery
        };
    }
}
