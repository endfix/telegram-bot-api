using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>createForumTopic</c> method.
/// </summary>
public sealed class CreateForumTopicParameters : ApiRequestParameters
{
    /// <summary>Gets the unique identifier or username of the target forum supergroup, or the identifier of a private chat.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Gets the topic name, containing 1-128 characters.</summary>
    public required string Name { get; init; }

    /// <summary>Gets the topic icon color in RGB format. Must be one of the colors supported by Telegram.</summary>
    public int? IconColor { get; init; }

    /// <summary>Gets the unique identifier of the custom emoji shown as the topic icon.</summary>
    public string? IconCustomEmojiId { get; init; }
}
