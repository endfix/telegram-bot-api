using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class InputProfilePhoto
{
    public abstract InputProfilePhotoTypes Type { get; }
}

public sealed class InputProfilePhotoStatic : InputProfilePhoto
{
    public override InputProfilePhotoTypes Type => InputProfilePhotoTypes.Static;

    public required string Photo { get; init; }
}

public sealed class InputProfilePhotoAnimated : InputProfilePhoto
{
    public override InputProfilePhotoTypes Type => InputProfilePhotoTypes.Animated;

    public required string Animation { get; init; }

    public float? MainFrameTimestamp { get; init; }
}
