namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents an animation file (GIF or H.264/MPEG-4 AVC video without sound).
/// </summary>
public sealed class Animation
{
    /// <summary>Identifier for this file, which can be used to download or reuse the file.</summary>
    public required string FileId { get; init; }

    /// <summary>Unique identifier for this file, stable over time and across bots.</summary>
    public required string FileUniqueId { get; init; }

    /// <summary>Video width as defined by the sender.</summary>
    public required int Width { get; init; }

    /// <summary>Video height as defined by the sender.</summary>
    public required int Height { get; init; }

    /// <summary>Duration of the video in seconds as defined by the sender.</summary>
    public required int Duration { get; init; }

    /// <summary>Optional animation thumbnail as defined by the sender.</summary>
    public PhotoSize? Thumbnail { get; init; }

    /// <summary>Optional original animation filename as defined by the sender.</summary>
    public string? FileName { get; init; }

    /// <summary>Optional MIME type of the file as defined by the sender.</summary>
    public string? MimeType { get; init; }

    /// <summary>Optional file size in bytes.</summary>
    public int? FileSize { get; init; }
}
