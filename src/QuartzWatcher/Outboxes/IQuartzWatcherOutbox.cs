namespace QuartzWatcher.Outboxes;

public interface IQuartzWatcherOutbox
{
    /// <summary>
    /// Sends a Quartz message to the outbox.
    /// </summary>
    /// <param name="message">The Quartz message to send.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task SendAsync(QuartzMessage message, CancellationToken cancellationToken = default);
}
