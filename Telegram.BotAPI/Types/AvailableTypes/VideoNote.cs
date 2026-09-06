namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a video message.</summary>
public sealed class VideoNote
{
    /// <summary>Identifier for this file, which can be used to download or reuse the file.</summary>
    public required string FileId { get; init; }

    /// <summary>Unique identifier for this file, stable over time and across bots.</summary>
    public required string FileUniqueId { get; init; }

    /// <summary>Video width and height, the diameter of the video message.</summary>
    public required int Length { get; init; }

    /// <summary>Duration of the video in seconds.</summary>
    public required int Duration { get; init; }

    /// <summary>Video thumbnail, if available.</summary>
    public PhotoSize? Thumbnail { get; init; }

    /// <summary>File size in bytes, if available.</summary>
    public int? FileSize { get; init; }
}
