namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a file ready to be downloaded.</summary>
public sealed class FileStruct
{
    /// <summary>Identifier for this file, which can be used to download or reuse it.</summary>
    public required string FileId { get; init; }

    /// <summary>Unique identifier for this file, stable over time and across bots.</summary>
    public required string FileUniqueId { get; init; }

    /// <summary>File size in bytes, if available.</summary>
    public int? FileSize { get; init; }

    /// <summary>File path. Use it with the Bot API file download URL, if available.</summary>
    public string? FilePath { get; init; }
}
