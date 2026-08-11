namespace Telegram.BotAPI.Types;

public readonly struct CoverSource : IFileSource
{
    private readonly object _value;
    private CoverSource(object value) => _value = value;

    public static implicit operator CoverSource(string fileId) => new(fileId);
    public static implicit operator CoverSource(InputFile inputFile) => new(inputFile);

    public object Value => _value;
}
