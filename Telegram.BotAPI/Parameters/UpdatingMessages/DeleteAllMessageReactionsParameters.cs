using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class DeleteAllMessageReactionsParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public long? UserId { get; init; }

    public long? ActorChatId { get; init; }
}
