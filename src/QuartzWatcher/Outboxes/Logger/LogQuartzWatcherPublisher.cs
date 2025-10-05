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

    /// <summary>
    /// Initializes a new instance of the <see cref="LogQuartzWatcherPublisher"/> class.
    /// </summary>
    /// <param name="logger">The logger used to write Quartz event messages.</param>
    /// <param name="options">The options snapshot providing QuartzWatcher settings.</param>
    /// <remarks>
    /// This constructor configures the publisher to log Quartz messages using the specified logger and log level from settings.
    /// </remarks>
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
    /// <param name="message">The Quartz message to publish.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task PublishAsync(QuartzMessage message, CancellationToken cancellationToken = default)
    {
        if (!_logger.IsEnabled(_logLevel))
        {
            return Task.CompletedTask;
        }

        _logger.Log(_logLevel,
            "Quartz Event: {EventName} | Category: {EventCategory} | Source: {Source} | CreatedAtUtc: {CreatedAtUtc} | Data: {@Data}",
            message.EventName,
            message.EventCategoryName,
            message.Application,
            message.CreatedAtUtc,
            message.Data);
        return Task.CompletedTask;
    }
}
