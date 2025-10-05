namespace QuartzWatcher.Events.Triggers;

/// <summary>
/// Represents an event that occurs when a Quartz trigger has completed.
/// </summary>
public sealed record TriggerCompletedEvent : IQuartzEvent
{
    private TriggerCompletedEvent()
    {
    }

    /// <summary>
    /// Gets the execution context information.
    /// </summary>
    public required ContextInfo Context { get; init; }

    /// <summary>
    /// Gets the scheduler instruction result.
    /// </summary>
    public required string SchedulerInstruction { get; init; }

    /// <summary>
    /// Gets the trigger information.
    /// </summary>
    public required TriggerInfo Trigger { get; init; }

    /// <summary>
    /// Creates a new instance of <see cref="TriggerCompletedEvent"/>.
    /// </summary>
    /// <param name="trigger">The trigger.</param>
    /// <param name="context">The job execution context.</param>
    /// <param name="schedulerInstruction">The scheduler instruction.</param>
    /// <returns>A new <see cref="TriggerCompletedEvent"/> instance.</returns>
    public static TriggerCompletedEvent Create(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction schedulerInstruction)
    {
        ArgumentNullException.ThrowIfNull(trigger, nameof(trigger));
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        return new()
        {
            Context = ContextInfo.Create(context),
            SchedulerInstruction = schedulerInstruction.ToString(),
            Trigger = TriggerInfo.Create(trigger)
        };
    }
}
