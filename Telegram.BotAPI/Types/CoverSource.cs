namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a cover supplied by a file ID or input file.</summary>
public readonly struct CoverSource : IFileSource
{
    private readonly object _value;
    private CoverSource(object value) => _value = value;

    /// <summary>Converts a file ID to a cover source.</summary>
    /// <param name="fileId">Telegram file ID of the cover.</param>
    /// <returns>A cover source containing the supplied file ID.</returns>
    public static implicit operator CoverSource(string fileId) => new(fileId);
    /// <summary>Converts an input file to a cover source.</summary>
    /// <param name="inputFile">Cover file to upload.</param>
    /// <returns>A cover source containing the supplied input file.</returns>
    public static implicit operator CoverSource(InputCoverFile inputFile) => new(inputFile);

    /// <summary>Gets the original file ID or input file.</summary>
    public object Value => _value;
}
