namespace Endfix.Telegram.BotAPI.Types;

public readonly struct AudioSource : IFileSource
{
    private readonly object _value;
    private AudioSource(object value) => _value = value;

    public static implicit operator AudioSource(string fileIdOrUrl) => new(fileIdOrUrl);
    public static implicit operator AudioSource(InputAudioFile inputAudioFile) => new(inputAudioFile);

    public object Value => _value;
}
