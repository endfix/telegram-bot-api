namespace Endfix.Telegram.BotAPI.Types;

public readonly struct VideoNoteSource : IFileSource
{
    private readonly object _value;
    private VideoNoteSource(object value) => _value = value;

    public static implicit operator VideoNoteSource(string fileIdOrUrl) => new(fileIdOrUrl);
    public static implicit operator VideoNoteSource(InputVideoNoteFile inputVideoNoteFile) => new(inputVideoNoteFile);

    public object Value => _value;
}
