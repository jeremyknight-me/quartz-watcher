namespace QuartzWatcher.Outboxes.Logger;

internal static class LogPublisherSettingsFactory
{
    internal static LogPublisherSettings Create(QuartzWatcherSettings settings)
    {
        Dictionary<string, string>? publisherSettings = settings.GetPublisherSettings(LogPublisherSettings.PublisherKey);
        if (publisherSettings is null || publisherSettings.Count == 0)
        {
            throw new ArgumentException("Log publisher settings are not configured.");
        }

        var level = "Information";
        if (publisherSettings.TryGetValue(nameof(LogPublisherSettings.Level), out var levelSetting) && !string.IsNullOrWhiteSpace(levelSetting))
        {
            level = levelSetting;
        }

        return new LogPublisherSettings
        {
            Level = level!
        };
    }
}
