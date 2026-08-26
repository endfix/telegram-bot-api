namespace Endfix.Telegram.BotAPI.Types;

public readonly struct StickerSource : IFileSource
{
    private readonly object _value;
    private StickerSource(object value) => _value = value;

    public static implicit operator StickerSource(string fileId) => new(fileId);
    public static implicit operator StickerSource(InputStickerFile inputFile) => new(inputFile);

    public object Value => _value;
}
