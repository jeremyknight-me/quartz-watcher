using Microsoft.Extensions.Options;
using QuartzWatcher.Events;

namespace QuartzWatcher;

internal sealed class QuartzMessageFactory
{
    private readonly IOptionsMonitor<QuartzWatcherSettings> _options;

    public QuartzMessageFactory(IOptionsMonitor<QuartzWatcherSettings> options)
    {
        _options = options;
    }

    private string Application => Settings.ApplicationName;
    private QuartzWatcherSettings Settings => _options.CurrentValue;

    public QuartzMessage CreateJobMessage<T>(T data) where T : IQuartzEvent
        => CreateMesssage(data, EventCategory.Job);

    public QuartzMessage CreateSchedulerMessage<T>(T data) where T : IQuartzEvent
        => CreateMesssage(data, EventCategory.Scheduler);

    public QuartzMessage CreateTriggerMessage<T>(T data) where T : IQuartzEvent
        => CreateMesssage(data, EventCategory.Trigger);

    private QuartzMessage CreateMesssage<T>(T data, EventCategory category) where T : IQuartzEvent
    {
        Type eventType = data.GetType();
        return new()
        {
            Data = data,
            Application = Application,
            EventCategory = category,
            EventName = eventType.Name,
            EventType = eventType
        };
    }
}
