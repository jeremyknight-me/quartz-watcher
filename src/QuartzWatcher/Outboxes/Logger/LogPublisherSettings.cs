using Microsoft.Extensions.Logging;

namespace QuartzWatcher.Outboxes.Logger;

internal sealed class LogPublisherSettings
{
    internal const string PublisherKey = "Log";

    public required string Level { get; init; }

    public LogLevel GetLogLevel()
        => Enum.TryParse(Level, true, out LogLevel level)
            ? level
            : LogLevel.Information;
}
