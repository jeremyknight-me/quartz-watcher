using Microsoft.Extensions.Options;
using QuartzWatcher.Events;

namespace QuartzWatcher;

/// <summary>
/// Factory for creating QuartzMessage instances from Quartz events.
/// </summary>
internal sealed class QuartzMessageFactory
{
    private readonly IOptionsMonitor<QuartzWatcherSettings> _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuartzMessageFactory"/> class.
    /// </summary>
    /// <param name="options">The options monitor for QuartzWatcher settings.</param>
    public QuartzMessageFactory(IOptionsMonitor<QuartzWatcherSettings> options)
    {
        _options = options;
    }

    private string Application => Settings.ApplicationName;
    private QuartzWatcherSettings Settings => _options.CurrentValue;

    /// <summary>
    /// Creates a QuartzMessage for a job event.
    /// </summary>
    /// <typeparam name="T">The type of the event data.</typeparam>
    /// <param name="data">The event data.</param>
    /// <returns>A QuartzMessage with job category.</returns>
    public QuartzMessage CreateJobMessage<T>(T data) where T : IQuartzEvent
        => CreateMessage(data, EventCategory.Job);

    /// <summary>
    /// Creates a QuartzMessage for a scheduler event.
    /// </summary>
    /// <typeparam name="T">The type of the event data.</typeparam>
    /// <param name="data">The event data.</param>
    /// <returns>A QuartzMessage with scheduler category.</returns>
    public QuartzMessage CreateSchedulerMessage<T>(T data) where T : IQuartzEvent
        => CreateMessage(data, EventCategory.Scheduler);

    /// <summary>
    /// Creates a QuartzMessage for a trigger event.
    /// </summary>
    /// <typeparam name="T">The type of the event data.</typeparam>
    /// <param name="data">The event data.</param>
    /// <returns>A QuartzMessage with trigger category.</returns>
    public QuartzMessage CreateTriggerMessage<T>(T data) where T : IQuartzEvent
        => CreateMessage(data, EventCategory.Trigger);

    private QuartzMessage CreateMessage<T>(T data, EventCategory category) where T : IQuartzEvent
    {
        ArgumentNullException.ThrowIfNull(data);
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
