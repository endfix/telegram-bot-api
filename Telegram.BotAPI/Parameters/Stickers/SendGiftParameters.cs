using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendGift</c> method.
/// </summary>
public sealed class SendGiftParameters : ApiRequestParameters
{
    /// <summary>Identifier of the target user who will receive the gift; required when <see cref="ChatId"/> is omitted.</summary>
    public long? UserId { get; init; }

    /// <summary>Identifier of the target chat or username of the channel that will receive the gift; required when <see cref="UserId"/> is omitted.</summary>
    public ChatIdSource? ChatId { get; init; }

    /// <summary>Gift identifier. Limited gifts cannot be sent to channel chats.</summary>
    public required string GiftId { get; init; }

    /// <summary>Whether the bot pays for the gift upgrade, making it free for the receiver.</summary>
    public bool? PayForUpgrade { get; init; }

    /// <summary>Text shown with the gift, from 0 through 128 characters.</summary>
    public string? Text { get; init; }

    /// <summary>
    /// Mode for parsing entities in <see cref="Text"/>. Entities other than bold, italic, underline,
    /// strikethrough, spoiler, custom emoji, and date-time entities are ignored.
    /// </summary>
    public string? TextParseMode { get; init; }

    /// <summary>
    /// Special entities in the gift text; can be specified instead of <see cref="TextParseMode"/>.
    /// Entities other than bold, italic, underline, strikethrough, spoiler, custom emoji, and date-time
    /// entities are ignored.
    /// </summary>
    public IReadOnlyList<MessageEntity>? TextEntities { get; init; }
}
