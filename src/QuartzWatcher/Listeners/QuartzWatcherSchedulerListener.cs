using Microsoft.Extensions.Logging;
using QuartzWatcher.Events;
using QuartzWatcher.Events.Schedulers;
using QuartzWatcher.Outboxes;

namespace QuartzWatcher.Listeners;

/// <summary>
/// Listens for Quartz scheduler events and publishes them to the outbox.
/// </summary>
internal sealed class QuartzWatcherSchedulerListener : QuartzWatcherListenerBase, ISchedulerListener
{
    public const string Name = nameof(QuartzWatcherSchedulerListener);
    private readonly IQuartzWatcherOutbox _outbox;
    private readonly QuartzMessageFactory _messageFactory;

    public QuartzWatcherSchedulerListener(
        ILogger<QuartzWatcherSchedulerListener> logger,
        IQuartzWatcherOutbox outbox,
        QuartzMessageFactory messageFactory)
        : base(logger ?? throw new ArgumentNullException(nameof(logger)))
    {
        _outbox = outbox ?? throw new ArgumentNullException(nameof(outbox));
        _messageFactory = messageFactory ?? throw new ArgumentNullException(nameof(messageFactory));
    }

    /// <inheritdoc />
    public async Task JobAdded(IJobDetail jobDetail, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = SchedulerJobAddedEvent.Create(jobDetail);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, Name);
        }
    }

    /// <inheritdoc />
    public async Task JobDeleted(JobKey jobKey, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = SchedulerJobDeletedEvent.Create(jobKey);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, Name);
        }
    }

    /// <inheritdoc />
    public async Task JobInterrupted(JobKey jobKey, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = SchedulerJobInterruptedEvent.Create(jobKey);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, Name);
        }
    }

    /// <inheritdoc />
    public async Task JobPaused(JobKey jobKey, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = SchedulerJobPausedEvent.Create(jobKey);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, Name);
        }
    }

    /// <inheritdoc />
    public async Task JobResumed(JobKey jobKey, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = SchedulerJobResumedEvent.Create(jobKey);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, Name);
        }
    }

    /// <inheritdoc />
    public async Task JobScheduled(ITrigger trigger, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = SchedulerJobScheduledEvent.Create(trigger);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, nameof(QuartzWatcherSchedulerListener));
        }
    }

    /// <inheritdoc />
    public async Task JobsPaused(string jobGroup, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = SchedulerJobsPausedEvent.Create(jobGroup);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, nameof(QuartzWatcherSchedulerListener));
        }
    }

    /// <inheritdoc />
    public async Task JobsResumed(string jobGroup, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = SchedulerJobsResumedEvent.Create(jobGroup);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, nameof(QuartzWatcherSchedulerListener));
        }
    }

    /// <inheritdoc />
    public async Task JobUnscheduled(TriggerKey triggerKey, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = SchedulerJobUnscheduledEvent.Create(triggerKey);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, nameof(QuartzWatcherSchedulerListener));
        }
    }

    /// <inheritdoc />
    public async Task SchedulerError(string msg, SchedulerException cause, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = SchedulerErroredEvent.Create(msg, cause);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, nameof(QuartzWatcherSchedulerListener));
        }
    }

    /// <inheritdoc />
    public async Task SchedulerInStandbyMode(CancellationToken cancellationToken = default)
    {
        try
        {
            SchedulerInStandbyModeEvent @event = new();
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, nameof(QuartzWatcherSchedulerListener));
        }
    }

    /// <inheritdoc />
    public async Task SchedulerShutdown(CancellationToken cancellationToken = default)
    {
        try
        {
            SchedulerShutdownEvent @event = new();
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, nameof(QuartzWatcherSchedulerListener));
        }
    }

    /// <inheritdoc />
    public async Task SchedulerShuttingdown(CancellationToken cancellationToken = default)
    {
        try
        {
            SchedulerShuttingDownEvent @event = new();
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, nameof(QuartzWatcherSchedulerListener));
        }
    }

    /// <inheritdoc />
    public async Task SchedulerStarted(CancellationToken cancellationToken = default)
    {
        try
        {
            SchedulerStartedEvent @event = new();
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, nameof(QuartzWatcherSchedulerListener));
        }
    }

    /// <inheritdoc />
    public async Task SchedulerStarting(CancellationToken cancellationToken = default)
    {
        try
        {
            SchedulerStartingEvent @event = new();
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, nameof(QuartzWatcherSchedulerListener));
        }
    }

    /// <inheritdoc />
    public async Task SchedulingDataCleared(CancellationToken cancellationToken = default)
    {
        try
        {
            SchedulerDataClearedEvent @event = new();
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, nameof(QuartzWatcherSchedulerListener));
        }
    }

    /// <inheritdoc />
    public async Task TriggerFinalized(ITrigger trigger, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = SchedulerTriggerFinalizedEvent.Create(trigger);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, nameof(QuartzWatcherSchedulerListener));
        }
    }

    /// <inheritdoc />
    public async Task TriggerPaused(TriggerKey triggerKey, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = SchedulerTriggerPausedEvent.Create(triggerKey);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, nameof(QuartzWatcherSchedulerListener));
        }
    }

    /// <inheritdoc />
    public async Task TriggerResumed(TriggerKey triggerKey, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = SchedulerTriggerResumedEvent.Create(triggerKey);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, nameof(QuartzWatcherSchedulerListener));
        }
    }

    /// <inheritdoc />
    public async Task TriggersPaused(string? triggerGroup, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = SchedulerTriggersPausedEvent.Create(triggerGroup);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, nameof(QuartzWatcherSchedulerListener));
        }
    }

    /// <inheritdoc />
    public async Task TriggersResumed(string? triggerGroup, CancellationToken cancellationToken = default)
    {
        try
        {
            var @event = SchedulerTriggersResumedEvent.Create(triggerGroup);
            await CreateMessageAndSendAsync(@event, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HandleException(ex, nameof(QuartzWatcherSchedulerListener));
        }
    }

    private async Task CreateMessageAndSendAsync<T>(T @event, CancellationToken cancellationToken)
        where T : IQuartzEvent
    {
        QuartzMessage message = _messageFactory.CreateSchedulerMessage(@event);
        await _outbox.SendAsync(message, cancellationToken).ConfigureAwait(false);
    }
}
