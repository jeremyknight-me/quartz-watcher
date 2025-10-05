using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using QuartzWatcher.Publishers;

namespace QuartzWatcher.Outboxes.Logger;

/// <summary>
/// Publishes Quartz messages to the application log using the configured log level.
/// </summary>
public sealed class LogQuartzWatcherPublisher : IQuartzWatcherPublisher
{
    private readonly ILogger<LogQuartzWatcherPublisher> _logger;
    private readonly LogLevel _logLevel;

    public LogQuartzWatcherPublisher(
        ILogger<LogQuartzWatcherPublisher> logger,
        IOptionsSnapshot<QuartzWatcherSettings> options)
    {
        _logger = logger;

        LogPublisherSettings settings = LogPublisherSettingsFactory.Create(options.Value);
        _logLevel = settings.GetLogLevel();
    }

    /// <summary>
    /// Publishes a Quartz message to the log if the log level is enabled.
    /// </summary>
    /// <param name="quartzEvent">The Quartz message to publish.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task PublishAsync(QuartzMessage quartzEvent, CancellationToken cancellationToken = default)
    {
        if (!_logger.IsEnabled(_logLevel))
        {
            return Task.CompletedTask;
        }

        _logger.Log(_logLevel,
            "Quartz Event: {EventName} | Category: {EventCategory} | Source: {Source} | CreatedAtUtc: {CreatedAtUtc} | Data: {@Data}",
            quartzEvent.EventName,
            quartzEvent.EventCategoryName,
            quartzEvent.Application,
            quartzEvent.CreatedAtUtc,
            quartzEvent.Data);
        return Task.CompletedTask;
    }
}
