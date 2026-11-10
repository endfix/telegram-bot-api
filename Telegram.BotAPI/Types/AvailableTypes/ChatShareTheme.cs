using Endfix.Telegram.BotAPI.Enums;
using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes the theme of the screen for sharing a link to a user or a chat.</summary>
public abstract class ChatShareTheme
{
    /// <summary>Type of the theme.</summary>
    public abstract ChatShareThemeType Type { get; }
}

/// <summary>Describes a theme with emoji placed on a background.</summary>
public sealed class ChatShareThemeEmoji : ChatShareTheme
{
    /// <summary>Type of the theme, always <c>emoji</c>.</summary>
    public override ChatShareThemeType Type => ChatShareThemeType.Emoji;

    /// <summary>Regular or custom emoji, from 0 through 6.</summary>
    public required IReadOnlyList<EmojiType> Emojis { get; init; }

    /// <summary>
    /// Identifier of the backdrop used as the background; omitted if the default background is
    /// used. Use <c>getChatShareThemeBackdrops</c> to get backdrop details.
    /// </summary>
    public int? BackgroundBackdropId { get; init; }
}

/// <summary>Describes a theme based on a unique gift owned by the user or the chat.</summary>
public sealed class ChatShareThemeUniqueGift : ChatShareTheme
{
    /// <summary>Type of the theme, always <c>unique_gift</c>.</summary>
    public override ChatShareThemeType Type => ChatShareThemeType.UniqueGift;

    /// <summary>The gift.</summary>
    public required UniqueGift Gift { get; init; }
}
