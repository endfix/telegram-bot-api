using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editForumTopic</c> method.
/// </summary>
public sealed class EditForumTopicParameters : ApiRequestParameters
{
    /// <summary>Target chat identifier or supergroup username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Identifier of the forum topic's message thread.</summary>
    public required long MessageThreadId { get; init; }

    /// <summary>New topic name, from 0 through 128 characters. An omitted or empty value preserves the current name.</summary>
    public string? Name { get; init; }

    /// <summary>New custom emoji identifier. Pass an empty string to remove the icon; omit it to preserve the current icon.</summary>
    public string? IconCustomEmojiId { get; init; }
}
