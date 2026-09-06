namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a video note supplied by a file ID, URL, or input file.</summary>
public readonly struct VideoNoteSource : IFileSource
{
    private readonly object _value;
    private VideoNoteSource(object value) => _value = value;

    /// <summary>Converts a file ID or URL to a video note source.</summary>
    public static implicit operator VideoNoteSource(string fileIdOrUrl) => new(fileIdOrUrl);
    /// <summary>Converts an input file to a video note source.</summary>
    public static implicit operator VideoNoteSource(InputVideoNoteFile inputVideoNoteFile) => new(inputVideoNoteFile);

    /// <summary>Gets the original file ID, URL, or input file.</summary>
    public object Value => _value;
}
