namespace Telegram.BotAPI.Types;

public readonly struct StickerSource
{
    private readonly object _value;
    private StickerSource(object value) => _value = value;

    public static implicit operator StickerSource(string fileId) => new(fileId);
    public static implicit operator StickerSource(InputFile inputFile) => new(inputFile);

    public object Value => _value;
}
