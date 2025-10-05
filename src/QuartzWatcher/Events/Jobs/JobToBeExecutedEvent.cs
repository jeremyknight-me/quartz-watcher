namespace QuartzWatcher.Events.Jobs;

public sealed record JobToBeExecutedEvent : IQuartzEvent
{
    private JobToBeExecutedEvent()
    {
    }

    public required ContextInfo Context { get; init; }

    public static JobToBeExecutedEvent Create(IJobExecutionContext context)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        return new JobToBeExecutedEvent
        {
            Context = ContextInfo.Create(context)
        };
    }
}
