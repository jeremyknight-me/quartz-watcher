using System.Text.Json.Serialization;

namespace QuartzWatcher;

/// <summary>
/// Represents a message containing information about a Quartz event.
/// </summary>
public sealed record QuartzMessage
{
    internal QuartzMessage()
    {
    }

    /// <summary>
    /// The name of the application that generated the event.
    /// </summary>
    public required string Application { get; init; }

    /// <summary>
    /// The name of the event.
    /// </summary>
    public required string EventName { get; init; }

    /// <summary>
    /// The category of the event.
    /// </summary>
    public required EventCategory EventCategory { get; init; }

    /// <summary>
    /// The string representation of the event category.
    /// </summary>
    public string EventCategoryName => EventCategory.ToString();

    /// <summary>
    /// The .NET type of the event data (not serialized).
    /// </summary>
    [JsonIgnore] public Type? EventType { get; init; }

    /// <summary>
    /// The UTC timestamp when the message was created.
    /// </summary>
    public DateTimeOffset CreatedAtUtc { get; init; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// The event data payload.
    /// </summary>
    public required object Data { get; init; }
}
