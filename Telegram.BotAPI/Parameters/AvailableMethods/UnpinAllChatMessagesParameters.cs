using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class UnpinAllChatMessagesParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
}
