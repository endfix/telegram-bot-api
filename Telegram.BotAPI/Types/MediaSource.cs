namespace Telegram.BotAPI.Types;

public readonly struct MediaSource : IFileSource
{
    private readonly object _value;
    private MediaSource(object value) => _value = value;

    public static implicit operator MediaSource(string fileIdOrUrl) => new(fileIdOrUrl);
    public static implicit operator MediaSource(InputFile inputFile) => new(inputFile);

    public object Value => _value;
}