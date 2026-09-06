using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a video file.</summary>
public sealed class Video
{
    /// <summary>Identifier for this file, which can be used to download or reuse the file.</summary>
    public required string FileId { get; init; }

    /// <summary>Unique identifier for this file, stable over time and across bots.</summary>
    public required string FileUniqueId { get; init; }

    /// <summary>Video width as defined by the sender.</summary>
    public required int Width { get; init; }

    /// <summary>Video height as defined by the sender.</summary>
    public required int Height { get; init; }

    /// <summary>Duration of the video in seconds.</summary>
    public required int Duration { get; init; }

    /// <summary>Video thumbnail, if available.</summary>
    public PhotoSize? Thumbnail { get; init; }

    /// <summary>Available sizes of the cover of the video in the message, if available.</summary>
    public IReadOnlyList<PhotoSize>? Cover { get; init; }

    /// <summary>Timestamp in seconds from which the video will play in the message.</summary>
    public int StartTimestamp { get; init; }

    /// <summary>List of available video qualities, if supplied.</summary>
    public IReadOnlyList<VideoQuality>? Qualities { get; init; }

    /// <summary>Original filename, if available.</summary>
    public string? FileName { get; init; }

    /// <summary>MIME type of the file, if available.</summary>
    public string? MimeType { get; init; }

    /// <summary>File size in bytes.</summary>
    public int? FileSize { get; init; }
}
