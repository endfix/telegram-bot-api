namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents media supplied by a Telegram file ID, URL, or typed input file.
/// </summary>
public readonly struct MediaSource : IFileSource
{
    private readonly object _value;
    private MediaSource(object value) => _value = value;

    /// <summary>Converts a Telegram file ID or URL to a media source.</summary>
    public static implicit operator MediaSource(string fileIdOrUrl) => new(fileIdOrUrl);

    /// <summary>Converts a typed input file to a media source.</summary>
    public static implicit operator MediaSource(InputFile inputFile) => new(inputFile);

    /// <summary>Gets the original file ID, URL, or typed input file.</summary>
    public object Value => _value;
}
