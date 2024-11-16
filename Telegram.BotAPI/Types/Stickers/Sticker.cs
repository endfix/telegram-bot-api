using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Types.Stickers;

public sealed class Sticker
{
    public string FileId { get; set; }

    public string FileUniqueId { get; set; }

    public string Type { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public bool IsAnimated { get; set; }

    public bool IsVideo { get; set; }

    public PhotoSize Thumbnail { get; set; }

    public string Emoji { get; set; }

    public string SetName { get; set; }

    public File PremiumAnimation { get; set; }

    public MaskPosition MaskPosition { get; set; }

    public string CustomEmojiId { get; set; }

    public bool NeedsRepainting { get; set; }

    public int FileSize { get; set; }

    public static class StickerTypes
    {
        public const string REGULAR = "regular";

        public const string MASK = "mask";

        public const string CUSTOM_EMOJI = "custom_emoji";
    }
}