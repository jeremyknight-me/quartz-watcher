namespace QuartzWatcher.Events.Jobs;

public sealed record JobWasExecutedEvent : IQuartzEvent
{
    private JobWasExecutedEvent()
    {
    }

    public required ContextInfo Context { get; init; }
    public bool HasException => Exception is not null;
    public required JobExecutionException? Exception { get; init; }

    public static JobWasExecutedEvent Create(IJobExecutionContext context, JobExecutionException? jobException)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        return new JobWasExecutedEvent
        {
            Context = ContextInfo.Create(context),
            Exception = jobException
        };
    }
}
