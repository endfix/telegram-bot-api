using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents a video file or video quality variant.
/// </summary>
public sealed class VideoQuality
{
    /// <summary>Identifier for this file, which can be used to download or reuse the file.</summary>
    public required string FileId { get; init; }

    /// <summary>Unique identifier for this file, stable over time and across bots.</summary>
    public required string FileUniqueId { get; init; }

    /// <summary>Video width.</summary>
    public required int Width { get; init; }

    /// <summary>Video height.</summary>
    public required int Height { get; init; }

    /// <summary>Video codec.</summary>
    public required VideoQualityCodec Codec { get; init; }

    /// <summary>Optional file size in bytes.</summary>
    public int? FileSize { get; init; }
}
