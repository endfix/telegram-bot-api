namespace Endfix.Telegram.BotAPI.Types;

public readonly struct ThumbnailSource : IFileSource
{
    private readonly object _value;
    private ThumbnailSource(object value) => _value = value;

    public static implicit operator ThumbnailSource(string fileId) => new(fileId);
    public static implicit operator ThumbnailSource(InputThumbnailFile inputFile) => new(inputFile);

    public object Value => _value;
}
