using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class VideoQuality
{
    public required string FileId { get; set; }

    public required string FileUniqueId { get; set; }

    public required int Width { get; set; }

    public required int Height { get; set; }

    public required VideoQualityCodecs Codec { get; set; }

    public int FileSize { get; set; }
}
