namespace Telegram.BotAPI.Types;

public readonly struct MediaSource
{
    private readonly object _value;
    private MediaSource(object value) => _value = value;

    public static implicit operator MediaSource(string fileIdOrUrl) => new(fileIdOrUrl);
    public static implicit operator MediaSource(InputFile file) => new(file);

    public object Value => _value;
}