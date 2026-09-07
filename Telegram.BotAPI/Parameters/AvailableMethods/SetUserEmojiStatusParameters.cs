using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setUserEmojiStatus</c> method.
/// </summary>
public sealed class SetUserEmojiStatusParameters : ApiRequestParameters
{
    /// <summary>Target user identifier.</summary>
    public required long UserId { get; init; }

    /// <summary>Custom emoji identifier to set. Pass an empty string to remove the status.</summary>
    public string? EmojiStatusCustomEmojiId { get; init; }

    /// <summary>Unix timestamp when the emoji status expires.</summary>
    public int? EmojiStatusExpirationDate { get; init; }
}
