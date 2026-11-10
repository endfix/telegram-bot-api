using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes an emoji used in a chat share theme.</summary>
public abstract class EmojiType
{
    /// <summary>Type of the emoji.</summary>
    public abstract EmojiTypes Type { get; }
}

/// <summary>Describes a regular emoji.</summary>
public sealed class EmojiTypeEmoji : EmojiType
{
    /// <summary>Type of the emoji, always <c>emoji</c>.</summary>
    public override EmojiTypes Type => EmojiTypes.Emoji;

    /// <summary>The emoji.</summary>
    public required string Emoji { get; init; }
}

/// <summary>Describes a custom emoji.</summary>
public sealed class EmojiTypeCustomEmoji : EmojiType
{
    /// <summary>Type of the emoji, always <c>custom_emoji</c>.</summary>
    public override EmojiTypes Type => EmojiTypes.CustomEmoji;

    /// <summary>
    /// Identifier of the custom emoji. Use <c>getCustomEmojiStickers</c> to get full information
    /// about the sticker.
    /// </summary>
    public required string CustomEmojiId { get; init; }
}
