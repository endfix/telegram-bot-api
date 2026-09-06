using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getGameHighScores</c> method.
/// </summary>
public sealed class GetGameHighScoresParameters : ApiRequestParameters
{
    /// <summary>Target user identifier.</summary>
    public required long UserId { get; init; }

    /// <summary>Chat identifier, required when <see cref="InlineMessageId"/> is not specified.</summary>
    public long? ChatId { get; init; }

    /// <summary>Message identifier, required when <see cref="InlineMessageId"/> is not specified.</summary>
    public long? MessageId { get; init; }

    /// <summary>Inline message identifier, required when <see cref="ChatId"/> and <see cref="MessageId"/> are not specified.</summary>
    public string? InlineMessageId { get; init; }
}
