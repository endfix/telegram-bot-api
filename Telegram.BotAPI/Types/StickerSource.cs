namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a sticker supplied by a file ID or input file.</summary>
public readonly struct StickerSource : IFileSource
{
    private readonly object _value;
    private StickerSource(object value) => _value = value;

    /// <summary>Converts a file ID to a sticker source.</summary>
    public static implicit operator StickerSource(string fileId) => new(fileId);
    /// <summary>Converts an input file to a sticker source.</summary>
    public static implicit operator StickerSource(InputStickerFile inputFile) => new(inputFile);

    /// <summary>Gets the original file ID or input file.</summary>
    public object Value => _value;
}
