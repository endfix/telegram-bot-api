namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an audio file supplied by a file ID, URL, or input file.</summary>
public readonly struct AudioSource : IFileSource
{
    private readonly object _value;
    private AudioSource(object value) => _value = value;

    /// <summary>Converts a file ID or URL to an audio source.</summary>
    /// <param name="fileIdOrUrl">Telegram file ID or HTTP URL of the audio file.</param>
    /// <returns>An audio source containing the supplied value.</returns>
    public static implicit operator AudioSource(string fileIdOrUrl) => new(fileIdOrUrl);
    /// <summary>Converts an input file to an audio source.</summary>
    /// <param name="inputAudioFile">Audio file to upload.</param>
    /// <returns>An audio source containing the supplied input file.</returns>
    public static implicit operator AudioSource(InputAudioFile inputAudioFile) => new(inputAudioFile);

    /// <summary>Gets the original file ID, URL, or input file.</summary>
    public object Value => _value;
}
