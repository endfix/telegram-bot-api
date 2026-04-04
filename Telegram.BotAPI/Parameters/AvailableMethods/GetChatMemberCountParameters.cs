using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class GetChatMemberCountParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
}
