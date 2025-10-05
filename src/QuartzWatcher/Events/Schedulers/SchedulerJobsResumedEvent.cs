namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerJobsResumedEvent : IQuartzEvent
{
    private SchedulerJobsResumedEvent()
    {
    }

    public required string JobGroup { get; init; }

    public static SchedulerJobsResumedEvent Create(string jobGroup)
        => new()
        {
            JobGroup = jobGroup
        };
}

