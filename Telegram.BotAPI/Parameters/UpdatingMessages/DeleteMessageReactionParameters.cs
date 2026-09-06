using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteMessageReaction</c> method.
/// </summary>
public sealed class DeleteMessageReactionParameters : ApiRequestParameters
{
    /// <summary>Chat containing the message.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Identifier of the message.</summary>
    public required long MessageId { get; init; }

    /// <summary>Identifier of the user whose reaction should be deleted.</summary>
    public long? UserId { get; init; }

    /// <summary>Identifier of the chat whose reaction should be deleted.</summary>
    public long? ActorChatId { get; init; }
}
