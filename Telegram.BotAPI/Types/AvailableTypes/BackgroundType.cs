using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes the type of a background.
/// </summary>
public abstract class BackgroundType
{
    /// <summary>
    /// Gets the type of the background.
    /// </summary>
    public abstract BackgroundTypes Type { get; }
}

/// <summary>
/// Represents a background taken directly from a built-in chat theme.
/// </summary>
public sealed class BackgroundTypeChatTheme : BackgroundType
{
    /// <inheritdoc />
    public override BackgroundTypes Type => BackgroundTypes.ChatTheme;

    /// <summary>
    /// The name of the chat theme, which is usually an emoji.
    /// </summary>
    public required string ThemeName { get; init; }
}

/// <summary>
/// Represents a background automatically filled based on the selected colors.
/// </summary>
public sealed class BackgroundTypeFill : BackgroundType
{
    /// <inheritdoc />
    public override BackgroundTypes Type => BackgroundTypes.Fill;

    /// <summary>
    /// The background fill.
    /// </summary>
    public required BackgroundFill Fill { get; init; }

    /// <summary>
    /// Dimming of the background in dark themes, as a percentage; 0-100.
    /// </summary>
    public required int DarkThemeDimming { get; init; }
}

/// <summary>
/// Represents a PNG or TGV pattern combined with the background fill chosen by the user.
/// </summary>
public sealed class BackgroundTypePattern : BackgroundType
{
    /// <inheritdoc />
    public override BackgroundTypes Type => BackgroundTypes.Pattern;

    /// <summary>
    /// The document containing the pattern.
    /// </summary>
    public required Document Document { get; init; }

    /// <summary>
    /// The background fill combined with the pattern.
    /// </summary>
    public required BackgroundFill Fill { get; init; }

    /// <summary>
    /// The intensity of the pattern when shown above the filled background; 0-100.
    /// </summary>
    public required int Intensity { get; init; }

    /// <summary>
    /// True if the background fill must be applied only to the pattern itself. For dark themes only.
    /// </summary>
    public bool? IsInverted { get; init; }

    /// <summary>
    /// True if the background moves slightly when the device is tilted.
    /// </summary>
    public bool? IsMoving { get; init; }
}

/// <summary>
/// Represents a wallpaper in the JPEG format.
/// </summary>
public sealed class BackgroundTypeWallpaper : BackgroundType
{
    /// <inheritdoc />
    public override BackgroundTypes Type => BackgroundTypes.Wallpaper;

    /// <summary>
    /// The document containing the wallpaper.
    /// </summary>
    public required Document Document { get; init; }

    /// <summary>
    /// Dimming of the background in dark themes, as a percentage; 0-100.
    /// </summary>
    public required int DarkThemeDimming { get; init; }

    /// <summary>
    /// True if the wallpaper is downscaled to fit in a 450x450 square and then box-blurred with radius 12.
    /// </summary>
    public bool? IsBlurred { get; init; }

    /// <summary>
    /// True if the background moves slightly when the device is tilted.
    /// </summary>
    public bool? IsMoving { get; init; }
}
