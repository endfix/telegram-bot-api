using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>verifyChat</c> method.
/// </summary>
public sealed class VerifyChatParameters : ApiRequestParameters
{
    /// <summary>
    /// Target bot, supergroup or channel identifier or username. Channel direct messages cannot
    /// be verified.
    /// </summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>
    /// Verification description, from 0 through 70 characters. Must be empty unless the
    /// organization may provide one.
    /// </summary>
    public string? CustomDescription { get; init; }

    /// <summary>
    /// Mode for parsing entities in the custom description. Only <c>text_link</c> entities are
    /// supported.
    /// </summary>
    public ParseMode? CustomDescriptionParseMode { get; init; }

    /// <summary>
    /// Explicit entities in the custom description; can be specified instead of
    /// <see cref="CustomDescriptionParseMode"/>. Only <c>text_link</c> entities are supported.
    /// </summary>
    public IReadOnlyList<MessageEntity>? CustomDescriptionEntities { get; init; }
}
