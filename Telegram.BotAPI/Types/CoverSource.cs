namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a cover supplied by a file ID or input file.</summary>
public readonly struct CoverSource : IFileSource
{
    private readonly object _value;
    private CoverSource(object value) => _value = value;

    /// <summary>Converts a file ID to a cover source.</summary>
    public static implicit operator CoverSource(string fileId) => new(fileId);
    /// <summary>Converts an input file to a cover source.</summary>
    public static implicit operator CoverSource(InputCoverFile inputFile) => new(inputFile);

    /// <summary>Gets the original file ID or input file.</summary>
    public object Value => _value;
}
