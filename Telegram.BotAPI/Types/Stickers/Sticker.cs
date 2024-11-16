using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Types.Stickers;

/// <summary>
/// This object represents a sticker.
/// </summary>
public sealed class Sticker
{
    /// <summary>
    /// Identifier for this file, which can be used to download or reuse the file
    /// </summary>
    public string FileId { get; set; }

    /// <summary>
    /// Unique identifier for this file, which is supposed to be the same over time and for different bots. 
    /// Can't be used to download or reuse the file.
    /// </summary>
    public string FileUniqueId { get; set; }

    /// <summary>
    /// Type of the sticker, currently one of “regular”, “mask”, “custom_emoji”. 
    /// The type of the sticker is independent from its format, which is determined by the fields is_animated and is_video.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Sticker width
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Sticker height
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// True, if the sticker is <see href="https://telegram.org/blog/animated-stickers">animated</see>
    /// </summary>
    public bool IsAnimated { get; set; }

    /// <summary>
    /// True, if the sticker is a <see href="https://telegram.org/blog/video-stickers-better-reactions">video sticker</see>
    /// </summary>
    public bool IsVideo { get; set; }

    /// <summary>
    /// Optional. Sticker thumbnail in the .WEBP or .JPG format
    /// </summary>
    public PhotoSize Thumbnail { get; set; }

    /// <summary>
    /// Optional. Emoji associated with the sticker
    /// </summary>
    public string Emoji { get; set; }

    /// <summary>
    /// Optional. Name of the sticker set to which the sticker belongs
    /// </summary>
    public string SetName { get; set; }

    /// <summary>
    /// Optional. For premium regular stickers, premium animation for the sticker
    /// </summary>
    public File PremiumAnimation { get; set; }

    /// <summary>
    /// Optional. For mask stickers, the position where the mask should be placed
    /// </summary>
    public MaskPosition MaskPosition { get; set; }

    /// <summary>
    /// Optional. For custom emoji stickers, unique identifier of the custom emoji
    /// </summary>
    public string CustomEmojiId { get; set; }

    /// <summary>
    /// Optional. True, if the sticker must be repainted to a text color in messages, 
    /// the color of the Telegram Premium badge in emoji status, white color on chat photos, or another appropriate color in other places
    /// </summary>
    public bool NeedsRepainting { get; set; }

    /// <summary>
    /// Optional. File size in bytes
    /// </summary>
    public int FileSize { get; set; }

    public static class Types
    {
        public const string REGULAR = "regular";

        public const string MASK = "mask";

        public const string CUSTOM_EMOJI = "custom_emoji";
    }
}