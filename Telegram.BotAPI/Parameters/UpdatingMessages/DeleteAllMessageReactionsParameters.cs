using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class DeleteAllMessageReactionsParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public long? UserId { get; init; }

    public long? ActorChatId { get; init; }
}
