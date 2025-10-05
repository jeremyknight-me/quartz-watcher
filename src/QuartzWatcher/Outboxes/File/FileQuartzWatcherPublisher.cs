using System.Text.Json;
using Microsoft.Extensions.Options;
using QuartzWatcher.Publishers;

namespace QuartzWatcher.Outboxes.File;

/// <summary>
/// Publishes Quartz events to JSON files in a configured directory.
/// </summary>
public sealed class FileQuartzWatcherPublisher : IQuartzWatcherPublisher
{
    private static readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = false,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };
    private static readonly JsonSerializerOptions _jsonOptionsIndented = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    private readonly string _path;
    private readonly bool _writeIndented;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileQuartzWatcherPublisher"/> class.
    /// </summary>
    /// <param name="options">The configuration options.</param>
    public FileQuartzWatcherPublisher(IOptionsSnapshot<QuartzWatcherSettings> options)
    {
        FilePublisherSettings settings = FilePublisherSettingsFactory.Create(options.Value);
        _path = settings.Path;
        _writeIndented = settings.Indent;
    }

    /// <summary>
    /// Publishes a Quartz event message to a JSON file.
    /// </summary>
    /// <param name="quartzEvent">The event to publish.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task PublishAsync(QuartzMessage quartzEvent, CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(
            quartzEvent,
            _writeIndented ? _jsonOptionsIndented : _jsonOptions);

        if (!Directory.Exists(_path))
        {
            throw new DirectoryNotFoundException($"The directory '{_path}' does not exist.");
        }

        var guid = $"{MakeGuid():N}";
        var filePath = Path.Combine(_path, $"{guid}.json");

        // Validate that filePath is within _path to prevent path traversal
        var fullDirPath = Path.GetFullPath(_path);
        var fullFilePath = Path.GetFullPath(filePath);
        if (!fullFilePath.StartsWith(fullDirPath, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Attempted path traversal in file name.");
        }

        await System.IO.File.WriteAllTextAsync(filePath, json, cancellationToken);
    }

    private Guid MakeGuid()
    {
#if NET9_0_OR_GREATER
        return Guid.CreateVersion7();
#else
        return Guid.NewGuid();
#endif
    }
}
