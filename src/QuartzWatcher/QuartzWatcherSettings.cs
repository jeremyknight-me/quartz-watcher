using System.ComponentModel.DataAnnotations;

namespace QuartzWatcher;

/// <summary>
/// Represents configuration settings for QuartzWatcher.
/// </summary>
public sealed record QuartzWatcherSettings
{
    /// <summary>
    /// The configuration section name for QuartzWatcher settings.
    /// </summary>
    public const string SectionName = "QuartzWatcher";

    /// <summary>
    /// The name of the application using QuartzWatcher.
    /// </summary>
    [Required]
    public required string ApplicationName { get; init; }

    /// <summary>
    /// Publisher configuration settings, keyed by publisher name.
    /// </summary>
    public required Dictionary<string, Dictionary<string, string>> Publishers { get; init; }

    // todo: add feature flags for each event type

    public Dictionary<string, string> GetPublisherSettings(string publisherKey)
    {
        if (Publishers is null)
        {
            return [];
        }

        return Publishers.TryGetValue(publisherKey, out Dictionary<string, string>? settings)
            ? settings
            : [];
    }
}
