using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class GetChatParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
}
