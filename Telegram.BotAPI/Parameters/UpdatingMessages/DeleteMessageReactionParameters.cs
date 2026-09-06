using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteMessageReaction</c> method.
/// </summary>
public sealed class DeleteMessageReactionParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required long MessageId { get; init; }

    public long? UserId { get; init; }

    public long? ActorChatId { get; init; }
}
