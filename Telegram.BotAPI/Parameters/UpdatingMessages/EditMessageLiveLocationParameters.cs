using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editMessageLiveLocation</c> method.
/// </summary>
public sealed class EditMessageLiveLocationParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the business connection.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Chat containing the message.</summary>
    public ChatIdSource? ChatId { get; init; }

    /// <summary>Identifier of the message to edit.</summary>
    public long? MessageId { get; init; }

    /// <summary>Identifier of the inline message to edit.</summary>
    public string? InlineMessageId { get; init; }

    /// <summary>Latitude of the new location.</summary>
    public required double Latitude { get; init; }

    /// <summary>Longitude of the new location.</summary>
    public required double Longitude { get; init; }

    /// <summary>New period in seconds during which the location can be updated.</summary>
    public int? LivePeriod { get; init; }

    /// <summary>Radius of uncertainty for the location in meters.</summary>
    public float? HorizontalAccuracy { get; init; }

    /// <summary>Direction of travel in degrees.</summary>
    public int? Heading { get; init; }

    /// <summary>Distance in meters for proximity alerts.</summary>
    public int? ProximityAlertRadius { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
