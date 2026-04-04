using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class UnpinChatMessageParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public required ChatIdSource ChatId { get; init; }

    public long? MessageId { get; init; }
}
