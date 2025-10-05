namespace QuartzWatcher.Outboxes.File;

internal sealed class FilePublisherSettings
{
    internal const string PublisherKey = "File";

    public required string Path { get; init; }
    public required bool Indent { get; init; }
}
