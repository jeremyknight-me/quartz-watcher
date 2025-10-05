using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QuartzWatcher.Publishers;

namespace QuartzWatcher.Outboxes.InMemory;

internal sealed class InMemoryOutboxWorker : BackgroundService
{
    private readonly ILogger<InMemoryOutboxWorker> _logger;
    private readonly InMemoryMessageQueue _queue;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public InMemoryOutboxWorker(
        ILogger<InMemoryOutboxWorker> logger,
        InMemoryMessageQueue queue,
        IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _queue = queue;
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (QuartzMessage message in _queue.Reader.ReadAllAsync(stoppingToken))
        {
            using IServiceScope scope = _serviceScopeFactory.CreateScope();
            IEnumerable<IQuartzWatcherPublisher> publishers = scope.ServiceProvider.GetRequiredService<IEnumerable<IQuartzWatcherPublisher>>();

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
