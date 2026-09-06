namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a thumbnail supplied by a file ID or input file.</summary>
public readonly struct ThumbnailSource : IFileSource
{
    private readonly object _value;
    private ThumbnailSource(object value) => _value = value;

    /// <summary>Converts a file ID to a thumbnail source.</summary>
    public static implicit operator ThumbnailSource(string fileId) => new(fileId);
    /// <summary>Converts an input file to a thumbnail source.</summary>
    public static implicit operator ThumbnailSource(InputThumbnailFile inputFile) => new(inputFile);

    /// <summary>Gets the original file ID or input file.</summary>
    public object Value => _value;
}
