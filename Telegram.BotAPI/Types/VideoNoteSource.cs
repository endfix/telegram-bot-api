namespace Telegram.BotAPI.Types;

public readonly struct VideoNoteSource
{
    private readonly object _value;
    private VideoNoteSource(object value) => _value = value;

    public static implicit operator VideoNoteSource(string fileIdOrUrl) => new(fileIdOrUrl);
    public static implicit operator VideoNoteSource(InputVideoNoteFile file) => new(file);

    public object Value => _value;
}
