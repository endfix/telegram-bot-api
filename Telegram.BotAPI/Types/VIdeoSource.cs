namespace Telegram.BotAPI.Types;

public readonly struct VideoSource
{
    private readonly object _value;
    private VideoSource(object value) => _value = value;

    public static implicit operator VideoSource(string fileIdOrUrl) => new(fileIdOrUrl);
    public static implicit operator VideoSource(InputVideoFile file) => new(file);

    public object Value => _value;
}
