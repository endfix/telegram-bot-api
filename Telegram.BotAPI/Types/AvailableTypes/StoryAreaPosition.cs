namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes the position of a clickable area within a story.
/// </summary>
public sealed class StoryAreaPosition
{
    /// <summary>
    /// The abscissa of the area's center, as a percentage of the media width.
    /// </summary>
    public required float XPercentage { get; init; }

    /// <summary>
    /// The ordinate of the area's center, as a percentage of the media height.
    /// </summary>
    public required float YPercentage { get; init; }

    /// <summary>
    /// The width of the area's rectangle, as a percentage of the media width.
    /// </summary>
    public required float WidthPercentage { get; init; }

    /// <summary>
    /// The height of the area's rectangle, as a percentage of the media height.
    /// </summary>
    public required float HeightPercentage { get; init; }

    /// <summary>
    /// The clockwise rotation angle of the rectangle, in degrees; 0-360.
    /// </summary>
    public required float RotationAngle { get; init; }

    /// <summary>
    /// The radius of the rectangle corner rounding, as a percentage of the media width.
    /// </summary>
    public required float CornerRadiusPercentage { get; init; }
}
