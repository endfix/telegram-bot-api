using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a live photo with a static photo and a short video.</summary>
public sealed class LivePhoto
{
    /// <summary>Available sizes of the corresponding static photo, if available.</summary>
    public IReadOnlyList<PhotoSize>? Photo { get; init; }

    /// <summary>Identifier of the video file.</summary>
    public required string FileId { get; init; }

    /// <summary>Unique identifier of the video file.</summary>
    public required string FileUniqueId { get; init; }

    /// <summary>Video width as defined by the sender.</summary>
    public required int Width { get; init; }

    /// <summary>Video height as defined by the sender.</summary>
    public required int Height { get; init; }

    /// <summary>Duration of the video in seconds.</summary>
    public required int Duration { get; init; }

    /// <summary>MIME type of the file, if available.</summary>
    public string? MimeType { get; init; }

    /// <summary>File size in bytes, if available.</summary>
    public int? FileSize { get; init; }
}
