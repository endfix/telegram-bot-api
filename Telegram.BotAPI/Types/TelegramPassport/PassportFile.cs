namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a file uploaded to Telegram Passport.</summary>
public sealed class PassportFile
{
    /// <summary>Identifier for this file, which can be used to download or reuse the file.</summary>
    public required string FileId { get; init; }

    /// <summary>Unique identifier for this file, stable over time and across bots; cannot be used to download or reuse the file.</summary>
    public required string FileUniqueId { get; init; }

    /// <summary>File size in bytes.</summary>
    public required int FileSize { get; init; }

    /// <summary>Unix time when the file was uploaded.</summary>
    public required int FileDate { get; init; }
}
