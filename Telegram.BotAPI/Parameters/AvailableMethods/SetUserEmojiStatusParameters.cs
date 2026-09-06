using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setUserEmojiStatus</c> method.
/// </summary>
public sealed class SetUserEmojiStatusParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public string? EmojiStatusCustomEmojiId { get; init; }

    public int? EmojiStatusExpirationDate { get; init; }
}
