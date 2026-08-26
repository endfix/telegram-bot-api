using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public abstract class BackgroundFill
{
    public abstract BackgroundFillType Type { get; }
}

public sealed class BackgroundFillSolid : BackgroundFill
{
    public override BackgroundFillType Type => BackgroundFillType.Solid;

    public required int Color { get; init; }
}

public sealed class BackgroundFillGradient : BackgroundFill
{
    public override BackgroundFillType Type => BackgroundFillType.Gradient;

    public required int TopColor { get; init; }

    public required int BottomColor { get; init; }

    public required int RotationAngle { get; init; }
}

public sealed class BackgroundFillFreeformGradient : BackgroundFill
{
    public override BackgroundFillType Type => BackgroundFillType.FreeformGradient;

    public required IReadOnlyList<int> Colors { get; init; }
}
