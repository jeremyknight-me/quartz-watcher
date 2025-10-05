namespace QuartzWatcher.Outboxes.File;

internal sealed class FilePublisherSettings
{
    internal const string PublisherKey = "File";

    public required string Path { get; init; }
    public bool Indent { get; init; } = false;
}
