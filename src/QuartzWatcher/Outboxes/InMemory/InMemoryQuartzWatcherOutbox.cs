namespace QuartzWatcher.Outboxes.InMemory;

internal sealed class InMemoryQuartzWatcherOutbox : IQuartzWatcherOutbox
{
    private readonly InMemoryMessageQueue _queue;

    public InMemoryQuartzWatcherOutbox(InMemoryMessageQueue queue)
    {
        _queue = queue;
    }

    /// <inheritdoc />
    public async Task SendAsync(QuartzMessage message, CancellationToken cancellationToken = default)
        => await _queue.Writer.WriteAsync(message, cancellationToken).ConfigureAwait(false);
}
