namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an animation supplied by a file ID, URL, or input file.</summary>
public readonly struct AnimationSource : IFileSource
{
    private readonly object _value;
    private AnimationSource(object value) => _value = value;

    /// <summary>Converts a file ID or URL to an animation source.</summary>
    /// <param name="fileIdOrUrl">Telegram file ID or HTTP URL of the animation.</param>
    /// <returns>An animation source containing the supplied value.</returns>
    public static implicit operator AnimationSource(string fileIdOrUrl) => new(fileIdOrUrl);
    /// <summary>Converts an input file to an animation source.</summary>
    /// <param name="inputAnimationFile">Animation file to upload.</param>
    /// <returns>An animation source containing the supplied input file.</returns>
    public static implicit operator AnimationSource(InputAnimationFile inputAnimationFile) => new(inputAnimationFile);

    /// <summary>Gets the original file ID, URL, or input file.</summary>
    public object Value => _value;
}
