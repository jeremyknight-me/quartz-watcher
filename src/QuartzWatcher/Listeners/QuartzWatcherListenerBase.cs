using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace QuartzWatcher.Listeners;

/// <summary>
/// Provides a base class for Quartz event listeners with common exception handling and logging functionality.
/// </summary>
internal abstract class QuartzWatcherListenerBase
{
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuartzWatcherListenerBase"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    protected QuartzWatcherListenerBase(ILogger logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Handles exceptions that occur during Quartz event processing and logs them.
    /// </summary>
    /// <param name="ex">The exception to handle.</param>
    /// <param name="listener">The name of the listener where the exception occurred.</param>
    /// <param name="methodName">The name of the method where the exception occurred. Automatically captured via <see cref="CallerMemberNameAttribute"/>.</param>
    protected void HandleException(Exception ex, string listener, [CallerMemberName] string methodName = "")
    {
        ArgumentNullException.ThrowIfNull(ex, nameof(ex));
        ArgumentException.ThrowIfNullOrWhiteSpace(listener, nameof(listener));
        ArgumentException.ThrowIfNullOrWhiteSpace(methodName, nameof(methodName));
        _logger.LogError(ex, "An error occurred while processing Quartz event '{EventName}' in listener '{ListenerName}'", methodName, listener);
    }
}
