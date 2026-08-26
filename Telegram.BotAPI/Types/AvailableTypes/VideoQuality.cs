using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class VideoQuality
{
    public required string FileId { get; init; }

    public required string FileUniqueId { get; init; }

    public required int Width { get; init; }

    public required int Height { get; init; }

    public required VideoQualityCodec Codec { get; init; }

    public int? FileSize { get; init; }
}
