namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a voice note.</summary>
public sealed class Voice
{
    /// <summary>Identifier for this file, which can be used to download or reuse the file.</summary>
    public required string FileId { get; init; }

    /// <summary>Unique identifier for this file, stable over time and across bots.</summary>
    public required string FileUniqueId { get; init; }

    /// <summary>Duration of the audio in seconds.</summary>
    public required int Duration { get; init; }

    /// <summary>MIME type of the file, if available.</summary>
    public string? MimeType { get; init; }

    /// <summary>File size in bytes, if available.</summary>
    public int? FileSize { get; init; }
}
