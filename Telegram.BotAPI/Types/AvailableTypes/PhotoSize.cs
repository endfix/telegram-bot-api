namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents one size of a photo or a file or sticker thumbnail.</summary>
public sealed class PhotoSize
{
    /// <summary>Identifier for this file, which can be used to download or reuse the file.</summary>
    public required string FileId { get; init; }

    /// <summary>Unique identifier for this file, stable over time and across bots, but not usable for downloading or reusing it.</summary>
    public required string FileUniqueId { get; init; }

    /// <summary>Photo width.</summary>
    public required int Width { get; init; }

    /// <summary>Photo height.</summary>
    public required int Height { get; init; }

    /// <summary>File size in bytes, if available.</summary>
    public int? FileSize { get; init; }
}
