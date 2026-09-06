using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a Telegram sticker.</summary>
public sealed class Sticker
{
    /// <summary>Identifier for this file.</summary>
    public required string FileId { get; init; }

    /// <summary>Unique identifier for this file.</summary>
    public required string FileUniqueId { get; init; }

    /// <summary>Sticker type.</summary>
    public required StickerType Type { get; init; }

    /// <summary>Sticker width.</summary>
    public required int Width { get; init; }

    /// <summary>Sticker height.</summary>
    public required int Height { get; init; }

    /// <summary>Indicates whether the sticker is animated.</summary>
    public required bool IsAnimated { get; init; }

    /// <summary>Indicates whether the sticker is a video sticker.</summary>
    public required bool IsVideo { get; init; }

    /// <summary>Sticker thumbnail, if available.</summary>
    public PhotoSize? Thumbnail { get; init; }

    /// <summary>Emoji associated with the sticker, if available.</summary>
    public string? Emoji { get; init; }

    /// <summary>Name of the sticker set, if available.</summary>
    public string? SetName { get; init; }

    /// <summary>Premium animation for the sticker, if available.</summary>
    public FileStruct? PremiumAnimation { get; init; }

    /// <summary>Position of the mask, if the sticker is a mask.</summary>
    public MaskPosition? MaskPosition { get; init; }

    /// <summary>Identifier of the custom emoji, if the sticker is a custom emoji.</summary>
    public string? CustomEmojiId { get; init; }

    /// <summary>Indicates whether the sticker needs repainting.</summary>
    public bool? NeedsRepainting { get; init; }

    /// <summary>File size in bytes, if available.</summary>
    public int? FileSize { get; init; }
}
