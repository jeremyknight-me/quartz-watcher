namespace QuartzWatcher.Outboxes.Logger;

internal static class LogPublisherSettingsFactory
{
    private static readonly string _defaultLevel = "Information";

    internal static LogPublisherSettings Create(QuartzWatcherSettings settings)
    {
        Dictionary<string, string>? publisherSettings = settings.GetPublisherSettings(LogPublisherSettings.PublisherKey);
        var level = publisherSettings is not null
            && publisherSettings.TryGetValue(nameof(LogPublisherSettings.Level), out var levelSetting)
            && !string.IsNullOrWhiteSpace(levelSetting)
            ? levelSetting
            : _defaultLevel;
        return new LogPublisherSettings
        {
            Level = level
        };
    }
}
