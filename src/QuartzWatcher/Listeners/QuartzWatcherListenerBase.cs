using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace QuartzWatcher.Listeners;

internal abstract class QuartzWatcherListenerBase
{
    private readonly ILogger _logger;

    protected QuartzWatcherListenerBase(ILogger logger)
    {
        _logger = logger;
    }

    protected void HandleException(Exception ex, string listener, [CallerMemberName] string methodName = "")
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(listener, nameof(listener));
        ArgumentException.ThrowIfNullOrWhiteSpace(methodName, nameof(methodName));
        _logger.LogError(ex, "An error occurred while processing Quartz event '{EventName}' in listener '{ListenerName}'", methodName, listener);
    }
}
