using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QuartzWatcher.Publishers;

namespace QuartzWatcher.Outboxes.InMemory;

/// <summary>
/// Background service that processes queued Quartz messages and publishes them to registered publishers.
/// </summary>
internal sealed class InMemoryOutboxWorker : BackgroundService
{
    private readonly ILogger<InMemoryOutboxWorker> _logger;
    private readonly InMemoryMessageQueue _queue;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="InMemoryOutboxWorker"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="queue">The message queue to read from.</param>
    /// <param name="serviceScopeFactory">The service scope factory for creating per-message scopes.</param>
    public InMemoryOutboxWorker(
        ILogger<InMemoryOutboxWorker> logger,
        InMemoryMessageQueue queue,
        IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _queue = queue ?? throw new ArgumentNullException(nameof(queue));
        _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (QuartzMessage message in _queue.Reader.ReadAllAsync(stoppingToken))
        {
            using IServiceScope scope = _serviceScopeFactory.CreateScope();
            IEnumerable<IQuartzWatcherPublisher> publishers = scope.ServiceProvider.GetServices<IQuartzWatcherPublisher>();

            // todo: attempt to find a way to make this more efficient
            foreach (IQuartzWatcherPublisher publisher in publishers)
            {
                try
                {
                    await publisher.PublishAsync(message, stoppingToken).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex,
                        "An error occurred while publishing Quartz event '{EventType}' using publisher '{PublisherType}'",
                        message.EventName,
                        publisher.GetType().Name);
                }
            }
        }
    }
}
