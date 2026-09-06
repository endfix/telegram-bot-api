using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteAllMessageReactions</c> method.
/// </summary>
public sealed class DeleteAllMessageReactionsParameters : ApiRequestParameters
{
    /// <summary>Chat containing the message.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Identifier of the user whose reactions should be deleted.</summary>
    public long? UserId { get; init; }

    /// <summary>Identifier of the chat whose reactions should be deleted.</summary>
    public long? ActorChatId { get; init; }
}
