namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a general file, as opposed to a photo, voice message or audio file.</summary>
public sealed class Document
{
    /// <summary>Identifier for this file, which can be used to download or reuse the file.</summary>
    public required string FileId { get; init; }

    /// <summary>Unique identifier for this file, stable over time and across bots, but not usable for downloading or reusing it.</summary>
    public required string FileUniqueId { get; init; }

    /// <summary>Document thumbnail as defined by the sender, if available.</summary>
    public PhotoSize? Thumbnail { get; init; }

    /// <summary>Original filename, if available.</summary>
    public string? FileName { get; init; }

    /// <summary>MIME type of the file, if available.</summary>
    public string? MimeType { get; init; }

    /// <summary>File size in bytes, if available.</summary>
    public int? FileSize { get; init; }
}
