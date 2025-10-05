namespace QuartzWatcher.Events;

/// <summary>
/// Contains information about a Quartz trigger.
/// </summary>
public sealed record TriggerInfo
{
    private TriggerInfo()
    {
    }

    /// <summary>
    /// The name of the calendar associated with the trigger, if any.
    /// </summary>
    public required string? CalendarName { get; init; }

    /// <summary>
    /// The data map associated with the trigger.
    /// </summary>
    public required IDictionary<string, object> DataMap { get; init; }

    /// <summary>
    /// The description of the trigger, if any.
    /// </summary>
    public required string? Description { get; init; }

    /// <summary>
    /// The UTC end time of the trigger, if any.
    /// </summary>
    public required DateTimeOffset? EndTimeUtc { get; init; }

    /// <summary>
    /// The UTC time of the final fire, if any.
    /// </summary>
    public required DateTimeOffset? FinalFireTimeUtc { get; init; }

    /// <summary>
    /// Indicates whether the trigger has millisecond precision.
    /// </summary>
    public required bool HasMillisecondPrecision { get; init; }

    /// <summary>
    /// The name of the job associated with the trigger.
    /// </summary>
    public required string JobName { get; init; }

    /// <summary>
    /// The group of the job associated with the trigger.
    /// </summary>
    public required string JobGroup { get; init; }

    /// <summary>
    /// Indicates whether the trigger may fire again.
    /// </summary>
    public required bool MayFireAgain { get; init; }

    /// <summary>
    /// The misfire instruction for the trigger.
    /// </summary>
    public required int MisfireInstruction { get; init; }

    /// <summary>
    /// The next scheduled fire time in UTC, if any.
    /// </summary>
    public required DateTimeOffset? NextFireTimeUtc { get; init; }

    /// <summary>
    /// The previous fire time in UTC, if any.
    /// </summary>
    public required DateTimeOffset? PreviousFireTimeUtc { get; init; }

    /// <summary>
    /// The priority of the trigger.
    /// </summary>
    public required int Priority { get; init; }

    /// <summary>
    /// The UTC start time of the trigger.
    /// </summary>
    public required DateTimeOffset StartTimeUtc { get; init; }

    /// <summary>
    /// The name of the trigger.
    /// </summary>
    public required string TriggerName { get; init; }

    /// <summary>
    /// The group of the trigger.
    /// </summary>
    public required string TriggerGroup { get; init; }

    public static TriggerInfo Create(ITrigger trigger)
        => new()
        {
            CalendarName = trigger.CalendarName,
            DataMap = trigger.JobDataMap,
            Description = trigger.Description,
            EndTimeUtc = trigger.EndTimeUtc,
            FinalFireTimeUtc = trigger.FinalFireTimeUtc,
            HasMillisecondPrecision = trigger.HasMillisecondPrecision,
            JobName = trigger.JobKey.Name,
            JobGroup = trigger.JobKey.Group,
            MayFireAgain = trigger.GetMayFireAgain(),
            MisfireInstruction = trigger.MisfireInstruction,
            NextFireTimeUtc = trigger.GetNextFireTimeUtc(),
            PreviousFireTimeUtc = trigger.GetPreviousFireTimeUtc(),
            Priority = trigger.Priority,
            StartTimeUtc = trigger.StartTimeUtc,
            TriggerName = trigger.Key.Name,
            TriggerGroup = trigger.Key.Group
        };
}
