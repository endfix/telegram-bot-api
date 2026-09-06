using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes the position on faces where a mask should be placed.
/// </summary>
public sealed class MaskPosition
{
    /// <summary>The point on the face relative to which the mask should be placed.</summary>
    public required MaskPositionPoint Point { get; init; }

    /// <summary>Shift by X-axis measured in widths of the mask scaled to the face size.</summary>
    public required float XShift { get; init; }

    /// <summary>Shift by Y-axis measured in heights of the mask scaled to the face size.</summary>
    public required float YShift { get; init; }

    /// <summary>Mask scaling coefficient.</summary>
    public required float Scale { get; init; }
}
