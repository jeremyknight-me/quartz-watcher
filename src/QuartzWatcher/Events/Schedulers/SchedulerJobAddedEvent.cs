namespace QuartzWatcher.Events.Schedulers;

public sealed record SchedulerJobAddedEvent : IQuartzEvent
{
    private SchedulerJobAddedEvent()
    {
    }

    public required string? Description { get; init; }
    public required string? Name { get; init; }
    public required string? Group { get; init; }
    public required string? TypeFullName { get; init; }
    public required IDictionary<string, object> DataMap { get; init; }
    public required bool Durable { get; init; }
    public required bool PersistJobDataAfterExecution { get; init; }
    public required bool ConcurrentExecutionDisallowed { get; init; }
    public required bool RequestsRecovery { get; init; }

    public static SchedulerJobAddedEvent Create(IJobDetail jobDetail)
        => new()
        {
            Description = jobDetail.Description,
            Name = jobDetail.Key.Name,
            Group = jobDetail.Key.Group,
            TypeFullName = jobDetail.JobType.FullName,
            DataMap = jobDetail.JobDataMap,
            Durable = jobDetail.Durable,
            PersistJobDataAfterExecution = jobDetail.PersistJobDataAfterExecution,
            ConcurrentExecutionDisallowed = jobDetail.ConcurrentExecutionDisallowed,
            RequestsRecovery = jobDetail.RequestsRecovery
        };
}
