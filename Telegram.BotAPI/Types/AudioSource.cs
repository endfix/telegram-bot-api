namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an audio file supplied by a file ID, URL, or input file.</summary>
public readonly struct AudioSource : IFileSource
{
    private readonly object _value;
    private AudioSource(object value) => _value = value;

    /// <summary>Converts a file ID or URL to an audio source.</summary>
    public static implicit operator AudioSource(string fileIdOrUrl) => new(fileIdOrUrl);
    /// <summary>Converts an input file to an audio source.</summary>
    public static implicit operator AudioSource(InputAudioFile inputAudioFile) => new(inputAudioFile);

    /// <summary>Gets the original file ID, URL, or input file.</summary>
    public object Value => _value;
}
