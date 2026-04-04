namespace Telegram.BotAPI.Types;

public readonly struct VoiceSource
{
    private readonly object _value;
    private VoiceSource(object value) => _value = value;

    public static implicit operator VoiceSource(string fileIdOrUrl) => new(fileIdOrUrl);
    public static implicit operator VoiceSource(InputVoiceFile file) => new(file);

    public object Value => _value;
}
