namespace QuartzWatcher.Publishers;

/// <summary>
/// Defines a contract for publishing Quartz messages to an external system or sink.
/// </summary>
public interface IQuartzWatcherPublisher
{
    public Task PublishAsync(QuartzMessage message, CancellationToken cancellationToken = default);
}
