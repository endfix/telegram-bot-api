using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;
namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>createNewStickerSet</c> method.
/// </summary>
public sealed class CreateNewStickerSetParameters : ApiRequestParameters
{
    /// <summary>Identifier of the user who owns the sticker set.</summary>
    public required long UserId { get; init; }

    /// <summary>Sticker set name.</summary>
    public required string Name { get; init; }

    /// <summary>Sticker set title.</summary>
    public required string Title { get; init; }

    /// <summary>Initial stickers in the set.</summary>
    public required IReadOnlyList<InputSticker> Stickers { get; init; }

    /// <summary>Type of stickers in the set.</summary>
    public StickerType? StickerType { get; init; }

    /// <summary>Whether stickers should be recolored for dark and light themes.</summary>
    public bool? NeedsRepainting { get; init; }
}
