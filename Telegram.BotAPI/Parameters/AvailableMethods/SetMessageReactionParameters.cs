using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setMessageReaction</c> method.
/// </summary>
public sealed class SetMessageReactionParameters : ApiRequestParameters
{
    /// <summary>Target chat identifier or username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target message identifier. For a media group, the reaction applies to its first non-deleted message.</summary>
    public required long MessageId { get; init; }

    /// <summary>Reaction types to set. An omitted or empty list removes the bot's reactions.</summary>
    public IReadOnlyList<ReactionType>? Reaction { get; init; }

    /// <summary>Whether to display the reaction with a large animation.</summary>
    public bool? IsBig { get; init; }
}
