namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a voice file supplied by a file ID, URL, or input file.</summary>
public readonly struct VoiceSource : IFileSource
{
    private readonly object _value;
    private VoiceSource(object value) => _value = value;

    /// <summary>Converts a file ID or URL to a voice source.</summary>
    public static implicit operator VoiceSource(string fileIdOrUrl) => new(fileIdOrUrl);
    /// <summary>Converts an input file to a voice source.</summary>
    public static implicit operator VoiceSource(InputVoiceFile inputVoiceFile) => new(inputVoiceFile);

    /// <summary>Gets the original file ID, URL, or input file.</summary>
    public object Value => _value;
}
