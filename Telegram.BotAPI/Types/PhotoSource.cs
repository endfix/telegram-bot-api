namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a photo supplied by a file ID, URL, or input file.</summary>
public readonly struct PhotoSource : IFileSource
{
    private readonly object _value;
    private PhotoSource(object value) => _value = value;

    /// <summary>Converts a file ID or URL to a photo source.</summary>
    public static implicit operator PhotoSource(string fileIdOrUrl) => new(fileIdOrUrl);
    /// <summary>Converts an input file to a photo source.</summary>
    public static implicit operator PhotoSource(InputPhotoFile inputPhotoFile) => new(inputPhotoFile);

    /// <summary>Gets the original file ID, URL, or input file.</summary>
    public object Value => _value;
}
