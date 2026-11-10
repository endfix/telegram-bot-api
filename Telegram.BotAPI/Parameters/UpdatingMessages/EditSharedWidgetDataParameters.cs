using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editSharedWidgetData</c> method.
/// </summary>
/// <remarks>A shared widget can be edited at most once per second.</remarks>
public sealed class EditSharedWidgetDataParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the shared widget.</summary>
    public required string WidgetId { get; init; }

    /// <summary>
    /// New public data of the widget, from 0 through 1024 bytes; pass an empty string to remove
    /// the data.
    /// </summary>
    public required string PublicData { get; init; }

    /// <summary>
    /// Maximum time in seconds that clients may cache the public data of the widget, from 5
    /// through 3600. The current value, 30 by default, is kept when the value is omitted.
    /// </summary>
    public int? CacheTime { get; init; }
}
