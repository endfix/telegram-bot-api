using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class GetChatMemberParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required long UserId { get; init; }
}
