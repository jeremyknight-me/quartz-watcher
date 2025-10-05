namespace QuartzWatcher.Events;

/// <summary>
/// Contains contextual information about a Quartz job execution.
/// </summary>
public sealed record ContextInfo
{
    private ContextInfo()
    {
    }

    /// <summary>
    /// The description of the calendar associated with the job, if any.
    /// </summary>
    public required string? CalendarDescription { get; init; }

    /// <summary>
    /// The unique identifier for the fire instance.
    /// </summary>
    public required string FireInstanceId { get; init; }

    /// <summary>
    /// The UTC time when the job was fired.
    /// </summary>
    public required DateTimeOffset FireTimeUtc { get; init; }

    /// <summary>
    /// Information about the job being executed.
    /// </summary>
    public required JobInfo Job { get; init; }

    /// <summary>
    /// The duration of the job run.
    /// </summary>
    public required TimeSpan JobRunTime { get; init; }

    /// <summary>
    /// The merged job data map for the execution context.
    /// </summary>
    public required IDictionary<string, object> MergedJobDataMap { get; init; }

    /// <summary>
    /// The next scheduled fire time in UTC, if any.
    /// </summary>
    public required DateTimeOffset? NextFireTimeUtc { get; init; }

    /// <summary>
    /// The previous fire time in UTC, if any.
    /// </summary>
    public required DateTimeOffset? PreviousFireTimeUtc { get; init; }

    /// <summary>
    /// Indicates whether the job is recovering from a failure.
    /// </summary>
    public required bool Recovering { get; init; }

    /// <summary>
    /// The name of the recovering trigger, if applicable.
    /// </summary>
    public required string? RecoveringTriggerName { get; init; }

    /// <summary>
    /// The group of the recovering trigger, if applicable.
    /// </summary>
    public required string? RecoveringTriggerGroup { get; init; }

    /// <summary>
    /// The number of times the job has been refired.
    /// </summary>
    public required int RefireCount { get; init; }

    /// <summary>
    /// The scheduled fire time in UTC, if any.
    /// </summary>
    public DateTimeOffset? ScheduledFireTimeUtc { get; init; }

    /// <summary>
    /// The name of the scheduler.
    /// </summary>
    public required string SchedulerName { get; init; }

    /// <summary>
    /// The instance ID of the scheduler.
    /// </summary>
    public required string SchedulerInstanceId { get; init; }

    /// <summary>
    /// Information about the trigger that fired the job.
    /// </summary>
    public required TriggerInfo Trigger { get; init; }

    public static ContextInfo Create(IJobExecutionContext context)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        return new()
        {
            CalendarDescription = context.Calendar?.Description,
            FireInstanceId = context.FireInstanceId,
            FireTimeUtc = context.FireTimeUtc,
            Job = JobInfo.Create(context.JobDetail),
            JobRunTime = context.JobRunTime,
            MergedJobDataMap = context.MergedJobDataMap,
            NextFireTimeUtc = context.NextFireTimeUtc,
            PreviousFireTimeUtc = context.PreviousFireTimeUtc,
            Recovering = context.Recovering,
            RecoveringTriggerName = context.Recovering ? context.RecoveringTriggerKey?.Name : null,
            RecoveringTriggerGroup = context.Recovering ? context.RecoveringTriggerKey?.Group : null,
            RefireCount = context.RefireCount,
            ScheduledFireTimeUtc = context.ScheduledFireTimeUtc,
            SchedulerName = context.Scheduler.SchedulerName,
            SchedulerInstanceId = context.Scheduler.SchedulerInstanceId,
            Trigger = TriggerInfo.Create(context.Trigger)
        };
    }
}
