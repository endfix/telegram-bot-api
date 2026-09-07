namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a video supplied by a file ID, URL, or input file.</summary>
public readonly struct VideoSource : IFileSource
{
    private readonly object _value;
    private VideoSource(object value) => _value = value;

    /// <summary>Converts a file ID or URL to a video source.</summary>
    /// <param name="fileIdOrUrl">Telegram file ID or HTTP URL of the video.</param>
    /// <returns>A video source containing the supplied value.</returns>
    public static implicit operator VideoSource(string fileIdOrUrl) => new(fileIdOrUrl);
    /// <summary>Converts an input file to a video source.</summary>
    /// <param name="inputVideoFile">Video file to upload.</param>
    /// <returns>A video source containing the supplied input file.</returns>
    public static implicit operator VideoSource(InputVideoFile inputVideoFile) => new(inputVideoFile);

    /// <summary>Gets the original file ID, URL, or input file.</summary>
    public object Value => _value;
}
