namespace QuartzWatcher.Publishers;

/// <summary>
/// Defines a contract for publishing Quartz messages to an external system or sink.
/// </summary>
public interface IQuartzWatcherPublisher
{
    /// <summary>
    /// Publishes a Quartz message asynchronously.
    /// </summary>
    /// <param name="message">The Quartz message to publish.</param>
    /// <param name="cancellationToken">Optional cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task PublishAsync(QuartzMessage message, CancellationToken cancellationToken = default);
}
