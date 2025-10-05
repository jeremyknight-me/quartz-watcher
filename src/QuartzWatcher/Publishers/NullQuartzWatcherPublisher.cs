namespace QuartzWatcher.Publishers;

/// <summary>
/// A no-op publisher that implements the null object pattern for QuartzWatcher publishing.
/// </summary>
public sealed class NullQuartzWatcherPublisher : IQuartzWatcherPublisher
{
    /// <summary>
    /// Does nothing. Implements the null object pattern for publishing.
    /// </summary>
    /// <param name="quartzEvent">The Quartz message to publish.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A completed task.</returns>
    public Task PublishAsync(QuartzMessage quartzEvent, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}
