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
    [Required]
    public required Dictionary<string, Dictionary<string, string>> Publishers { get; init; }

    /// <summary>
    /// Retrieves publisher-specific settings for the given publisher key.
    /// </summary>
    /// <param name="publisherKey">The key identifying the publisher.</param>
    /// <returns>A dictionary of settings for the publisher, or an empty dictionary if not found.</returns>
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
