using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class GetUserChatBoostsParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required long UserId { get; init; }
}
