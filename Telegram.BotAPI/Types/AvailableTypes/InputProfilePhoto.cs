using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class InputProfilePhoto
{
    public abstract InputProfilePhotoType Type { get; }
}

public sealed class InputProfilePhotoStatic : InputProfilePhoto
{
    public override InputProfilePhotoType Type => InputProfilePhotoType.Static;

    public required string Photo { get; init; }
}

public sealed class InputProfilePhotoAnimated : InputProfilePhoto
{
    public override InputProfilePhotoType Type => InputProfilePhotoType.Animated;

    public required string Animation { get; init; }

    public float? MainFrameTimestamp { get; init; }
}
