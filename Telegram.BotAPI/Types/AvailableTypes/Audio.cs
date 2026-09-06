namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an audio file to be treated as music by Telegram clients.</summary>
public sealed class Audio
{
    /// <summary>Identifier for this file, which can be used to download or reuse the file.</summary>
    public required string FileId { get; init; }

    /// <summary>Unique identifier for this file, stable over time and across bots.</summary>
    public required string FileUniqueId { get; init; }

    /// <summary>Duration of the audio in seconds.</summary>
    public required int Duration { get; init; }

    /// <summary>Performer of the audio, if available.</summary>
    public string? Performer { get; init; }

    /// <summary>Title of the audio, if available.</summary>
    public string? Title { get; init; }

    /// <summary>Original filename, if available.</summary>
    public string? FileName { get; init; }

    /// <summary>MIME type of the file, if available.</summary>
    public string? MimeType { get; init; }

    /// <summary>File size in bytes, if available.</summary>
    public int? FileSize { get; init; }

    /// <summary>Thumbnail of the album cover, if available.</summary>
    public PhotoSize? Thumbnail { get; init; }
}
