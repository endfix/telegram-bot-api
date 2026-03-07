using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class VideoQuality
{
    public required string FileId { get; init; }

    public required string FileUniqueId { get; init; }

    public required int Width { get; init; }

    public required int Height { get; init; }

    public required VideoQualityCodecs Codec { get; init; }

    public int? FileSize { get; init; }
}
