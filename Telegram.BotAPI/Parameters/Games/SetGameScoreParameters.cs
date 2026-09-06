using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setGameScore</c> method.
/// </summary>
public sealed class SetGameScoreParameters : ApiRequestParameters
{
    /// <summary>Identifier of the user whose score should be set.</summary>
    public required long UserId { get; init; }

    /// <summary>New non-negative score.</summary>
    public required int Score { get; init; }

    /// <summary>Whether to allow decreasing the user's high score.</summary>
    public bool? Force { get; init; }

    /// <summary>Whether to prevent automatic scoreboard updates.</summary>
    public bool? DisableEditMessage { get; init; }

    /// <summary>Chat containing the ordinary game message.</summary>
    public long? ChatId { get; init; }

    /// <summary>Identifier of the ordinary game message.</summary>
    public long? MessageId { get; init; }

    /// <summary>Identifier of the inline game message.</summary>
    public string? InlineMessageId { get; init; }
}
