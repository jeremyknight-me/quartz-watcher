namespace QuartzWatcher.Events.Jobs;

public sealed record JobExecutionVetoedEvent : IQuartzEvent
{
    private JobExecutionVetoedEvent()
    {
    }

    public required ContextInfo Context { get; init; }

    public static JobExecutionVetoedEvent Create(IJobExecutionContext context)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        return new JobExecutionVetoedEvent
        {
            Context = ContextInfo.Create(context)
        };
    }
}
