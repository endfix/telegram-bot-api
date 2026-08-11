namespace Telegram.BotAPI.Types;

public readonly struct AnimationSource : IFileSource
{
    private readonly object _value;
    private AnimationSource(object value) => _value = value;

    public static implicit operator AnimationSource(string fileIdOrUrl) => new(fileIdOrUrl);
    public static implicit operator AnimationSource(InputAnimationFile inputAnimationFile) => new(inputAnimationFile);

    public object Value => _value;
}
