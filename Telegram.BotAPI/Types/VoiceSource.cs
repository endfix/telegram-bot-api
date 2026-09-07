namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a voice file supplied by a file ID, URL, or input file.</summary>
public readonly struct VoiceSource : IFileSource
{
    private readonly object _value;
    private VoiceSource(object value) => _value = value;

    /// <summary>Converts a file ID or URL to a voice source.</summary>
    /// <param name="fileIdOrUrl">Telegram file ID or HTTP URL of the voice file.</param>
    /// <returns>A voice source containing the supplied value.</returns>
    public static implicit operator VoiceSource(string fileIdOrUrl) => new(fileIdOrUrl);
    /// <summary>Converts an input file to a voice source.</summary>
    /// <param name="inputVoiceFile">Voice file to upload.</param>
    /// <returns>A voice source containing the supplied input file.</returns>
    public static implicit operator VoiceSource(InputVoiceFile inputVoiceFile) => new(inputVoiceFile);

    /// <summary>Gets the original file ID, URL, or input file.</summary>
    public object Value => _value;
}
