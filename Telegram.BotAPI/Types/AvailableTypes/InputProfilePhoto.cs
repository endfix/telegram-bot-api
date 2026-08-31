using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public abstract class InputProfilePhoto
{
    public abstract InputProfilePhotoType Type { get; }
}

public sealed class InputProfilePhotoStatic : InputProfilePhoto
{
    public override InputProfilePhotoType Type => InputProfilePhotoType.Static;

    public required InputPhotoFile Photo { get; init; }
}

public sealed class InputProfilePhotoAnimated : InputProfilePhoto
{
    public override InputProfilePhotoType Type => InputProfilePhotoType.Animated;

    public required InputAnimationFile Animation { get; init; }

    public float? MainFrameTimestamp { get; init; }
}
