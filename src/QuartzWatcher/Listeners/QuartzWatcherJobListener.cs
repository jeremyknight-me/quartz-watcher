using Microsoft.Extensions.Logging;
using QuartzWatcher.Events;
using QuartzWatcher.Events.Jobs;
using QuartzWatcher.Outboxes;

namespace QuartzWatcher.Listeners;

/// <summary>
/// Listens for Quartz job events and publishes them to the outbox.
/// </summary>
internal sealed class QuartzWatcherJobListener : QuartzWatcherListenerBase, IJobListener
{
    private readonly IQuartzWatcherOutbox _outbox;
    private readonly QuartzMessageFactory _messageFactory;

    public QuartzWatcherJobListener(
        ILogger<QuartzWatcherJobListener> logger,
        IQuartzWatcherOutbox outbox,
        QuartzMessageFactory messageFactory)
        : base(logger)
    {
        _outbox = outbox;
        _messageFactory = messageFactory;
    }

    /// <inheritdoc />
    public string Name => nameof(QuartzWatcherJobListener);

    /// <inheritdoc />
    public async Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = JobExecutionVetoedEvent.Create(context);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, Name);
        }
    }

    /// <inheritdoc />
    public async Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = JobToBeExecutedEvent.Create(context);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, Name);
        }
    }

    /// <inheritdoc />
    public async Task JobWasExecuted(IJobExecutionContext context, JobExecutionException? jobException, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = JobWasExecutedEvent.Create(context, jobException);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, Name);
        }
    }

    private async Task CreateMessageAndSendAsync<T>(T @event, CancellationToken cancellationToken)
        where T : IQuartzEvent
    {
        QuartzMessage message = _messageFactory.CreateSchedulerMessage(@event);
        await _outbox.SendAsync(message, cancellationToken).ConfigureAwait(false);
    }
}
