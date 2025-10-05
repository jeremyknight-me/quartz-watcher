using Microsoft.Extensions.Logging;
using QuartzWatcher.Events;
using QuartzWatcher.Events.Triggers;
using QuartzWatcher.Outboxes;

namespace QuartzWatcher.Listeners;

/// <summary>
/// Listens for Quartz trigger events and publishes them to the outbox.
/// </summary>
internal sealed class QuartzWatcherTriggerListener : QuartzWatcherListenerBase, ITriggerListener
{
    private readonly IQuartzWatcherOutbox _outbox;
    private readonly QuartzMessageFactory _messageFactory;

    public QuartzWatcherTriggerListener(
        ILogger<QuartzWatcherTriggerListener> logger,
        IQuartzWatcherOutbox outbox,
        QuartzMessageFactory messageFactory)
        : base(logger ?? throw new ArgumentNullException(nameof(logger)))
    {
        _outbox = outbox ?? throw new ArgumentNullException(nameof(outbox));
        _messageFactory = messageFactory ?? throw new ArgumentNullException(nameof(messageFactory));
    }

    /// <inheritdoc />
    public string Name => nameof(QuartzWatcherTriggerListener);

    /// <inheritdoc />
    public async Task TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = TriggerCompletedEvent.Create(trigger, context, triggerInstructionCode);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, Name);
        }
    }

    /// <inheritdoc />
    public async Task TriggerFired(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = TriggerFiredEvent.Create(trigger, context);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, Name);
        }
    }

    /// <inheritdoc />
    public async Task TriggerMisfired(ITrigger trigger, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = TriggerMisfiredEvent.Create(trigger);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, Name);
        }
    }

    /// <inheritdoc />
    public Task<bool> VetoJobExecution(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default)
        => Task.FromResult(false); // Default behavior: do not veto job execution

    private async Task CreateMessageAndSendAsync<T>(T @event, CancellationToken cancellationToken)
        where T : IQuartzEvent
    {
        QuartzMessage message = _messageFactory.CreateTriggerMessage(@event);
        await _outbox.SendAsync(message, cancellationToken).ConfigureAwait(false);
    }
}
