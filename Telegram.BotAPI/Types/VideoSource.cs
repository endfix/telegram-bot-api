namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a video supplied by a file ID, URL, or input file.</summary>
public readonly struct VideoSource : IFileSource
{
    private readonly object _value;
    private VideoSource(object value) => _value = value;

    /// <summary>Converts a file ID or URL to a video source.</summary>
    public static implicit operator VideoSource(string fileIdOrUrl) => new(fileIdOrUrl);
    /// <summary>Converts an input file to a video source.</summary>
    public static implicit operator VideoSource(InputVideoFile inputVideoFile) => new(inputVideoFile);

    /// <summary>Gets the original file ID, URL, or input file.</summary>
    public object Value => _value;
}
