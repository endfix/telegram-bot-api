using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes the way a background is filled based on the selected colors.
/// </summary>
public abstract class BackgroundFill
{
    /// <summary>
    /// Gets the type of the background fill.
    /// </summary>
    public abstract BackgroundFillType Type { get; }
}

/// <summary>
/// Represents a background filled using a single color.
/// </summary>
public sealed class BackgroundFillSolid : BackgroundFill
{
    /// <inheritdoc />
    public override BackgroundFillType Type => BackgroundFillType.Solid;

    /// <summary>
    /// The color of the background fill in the RGB24 format.
    /// </summary>
    public required int Color { get; init; }
}

/// <summary>
/// Represents a gradient background fill.
/// </summary>
public sealed class BackgroundFillGradient : BackgroundFill
{
    /// <inheritdoc />
    public override BackgroundFillType Type => BackgroundFillType.Gradient;

    /// <summary>
    /// The top color of the gradient in the RGB24 format.
    /// </summary>
    public required int TopColor { get; init; }

    /// <summary>
    /// The bottom color of the gradient in the RGB24 format.
    /// </summary>
    public required int BottomColor { get; init; }

    /// <summary>
    /// The clockwise rotation angle of the background fill in degrees; 0-359.
    /// </summary>
    public required int RotationAngle { get; init; }
}

/// <summary>
/// Represents a freeform gradient background that rotates after every message in the chat.
/// </summary>
public sealed class BackgroundFillFreeformGradient : BackgroundFill
{
    /// <inheritdoc />
    public override BackgroundFillType Type => BackgroundFillType.FreeformGradient;

    /// <summary>
    /// The 3 or 4 base colors used to generate the freeform gradient in the RGB24 format.
    /// </summary>
    public required IReadOnlyList<int> Colors { get; init; }
}
