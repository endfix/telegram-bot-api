namespace Endfix.Telegram.BotAPI.Types;

public readonly struct VideoSource : IFileSource
{
    private readonly object _value;
    private VideoSource(object value) => _value = value;

    public static implicit operator VideoSource(string fileIdOrUrl) => new(fileIdOrUrl);
    public static implicit operator VideoSource(InputVideoFile inputVideoFile) => new(inputVideoFile);

    public object Value => _value;
}
