using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getGameHighScores</c> method.
/// </summary>
public sealed class GetGameHighScoresParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public long? ChatId { get; init; }

    public long? MessageId { get; init; }

    public string? InlineMessageId { get; init; }
}
