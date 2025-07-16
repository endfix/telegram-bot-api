using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class InputProfilePhoto
{
    public abstract InputProfilePhotoTypes Type { get; }
}

public sealed class InputProfilePhotoStatic : InputProfilePhoto
{
    public override InputProfilePhotoTypes Type => InputProfilePhotoTypes.Static;

    public string Photo { get; set; }
}

public sealed class InputProfilePhotoAnimated : InputProfilePhoto
{
    public override InputProfilePhotoTypes Type => InputProfilePhotoTypes.Animated;

    public string Animation { get; set; }

    public float MainFrameTimestamp { get; set; }
}
