namespace Telegram.BotAPI.Types;

public readonly struct PhotoSource
{
    private readonly object _value;
    private PhotoSource(object value) => _value = value;

    public static implicit operator PhotoSource(string fileIdOrUrl) => new(fileIdOrUrl);
    public static implicit operator PhotoSource(InputPhotoFile inputPhotoFile) => new(inputPhotoFile);

    public object Value => _value;
}
