namespace QuartzWatcher.Outboxes.File;

internal static class FilePublisherSettingsFactory
{
    internal static FilePublisherSettings Create(QuartzWatcherSettings settings)
    {
        Dictionary<string, string>? publisherSettings = settings.GetPublisherSettings(FilePublisherSettings.PublisherKey);
        if (publisherSettings is null || publisherSettings.Count == 0)
        {
            throw new ArgumentException("File publisher settings are not configured.");
        }

        if (!publisherSettings.TryGetValue(nameof(FilePublisherSettings.Path), out var path) || string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("Path for FileQuartzWatcherPublisher is not configured properly.");
        }

        bool writeIndented = false;
        if (publisherSettings.TryGetValue(nameof(FilePublisherSettings.Indent), out var writeIndentedStr)
            && bool.TryParse(writeIndentedStr, out var indent))
        {
            writeIndented = indent;
        }

        return new FilePublisherSettings
        {
            Path = path!,
            Indent = writeIndented
        };
    }
}
