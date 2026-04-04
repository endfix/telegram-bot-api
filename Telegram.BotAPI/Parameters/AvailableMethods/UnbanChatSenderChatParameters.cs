using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class UnbanChatSenderChatParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required long SenderChatId { get; init; }
}
