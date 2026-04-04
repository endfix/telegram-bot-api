using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class PinChatMessageParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public required ChatIdSource ChatId { get; init; }

    public required long MessageId { get; init; }

    public bool? DisableNotification { get; init; }
}
