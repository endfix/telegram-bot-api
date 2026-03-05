using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class Sticker
{
    public required string FileId { get; init; }

    public required string FileUniqueId { get; init; }

    public required StickerTypes Type { get; init; }

    public required int Width { get; init; }

    public required int Height { get; init; }

    public required bool IsAnimated { get; init; }

    public required bool IsVideo { get; init; }

    public PhotoSize? Thumbnail { get; init; }

    public string? Emoji { get; init; }

    public string? SetName { get; init; }

    public FileStruct? PremiumAnimation { get; init; }

    public MaskPosition? MaskPosition { get; init; }

    public string? CustomEmojiId { get; init; }

    public bool? NeedsRepainting { get; init; }

    public int? FileSize { get; init; }
}