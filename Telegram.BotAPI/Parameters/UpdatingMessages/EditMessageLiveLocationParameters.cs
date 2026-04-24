using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class EditMessageLiveLocationParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public ChatIdSource? ChatId { get; init; }

    public long? MessageId { get; init; }

    public string? InlineMessageId { get; init; }

    public required double Latitude { get; init; }

    public required double Longitude { get; init; }

    public int? LivePeriod { get; init; }

    public float? HorizontalAccuracy { get; init; }

    public int? Heading { get; init; }

    public int? ProximityAlertRadius { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
