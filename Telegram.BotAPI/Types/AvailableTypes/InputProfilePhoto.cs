using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a profile photo to be set for a bot or a business account.
/// </summary>
public abstract class InputProfilePhoto
{
    /// <summary>Gets the type of the profile photo.</summary>
    public abstract InputProfilePhotoType Type { get; }
}

/// <summary>Represents a static profile photo.</summary>
public sealed class InputProfilePhotoStatic : InputProfilePhoto
{
    /// <inheritdoc />
    public override InputProfilePhotoType Type => InputProfilePhotoType.Static;

    /// <summary>The static profile photo to set.</summary>
    public required InputPhotoFile Photo { get; init; }
}

/// <summary>Represents an animated profile photo.</summary>
public sealed class InputProfilePhotoAnimated : InputProfilePhoto
{
    /// <inheritdoc />
    public override InputProfilePhotoType Type => InputProfilePhotoType.Animated;

    /// <summary>The animated profile photo to set.</summary>
    public required InputAnimationFile Animation { get; init; }

    /// <summary>Optional timestamp in seconds of the frame that will be used as the profile photo preview.</summary>
    public float? MainFrameTimestamp { get; init; }
}
