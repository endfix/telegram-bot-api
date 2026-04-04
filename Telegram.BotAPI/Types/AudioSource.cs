namespace Telegram.BotAPI.Types;

public readonly struct AudioSource
{
    private readonly object _value;
    private AudioSource(object value) => _value = value;

    public static implicit operator AudioSource(string fileIdOrUrl) => new(fileIdOrUrl);
    public static implicit operator AudioSource(InputAudioFile file) => new(file);

    public object Value => _value;
}
