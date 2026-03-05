using System.Collections.Generic;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class BackgroundFill
{
    public abstract BackgroundFillTypes Type { get; }
}

public sealed class BackgroundFillSolid : BackgroundFill
{
    public override BackgroundFillTypes Type => BackgroundFillTypes.Solid;

    public required int Color { get; init; }
}

public sealed class BackgroundFillGradient : BackgroundFill
{
    public override BackgroundFillTypes Type => BackgroundFillTypes.Gradient;

    public required int TopColor { get; init; }

    public required int BottomColor { get; init; }

    public required int RotationAngle { get; init; }
}

public sealed class BackgroundFillFreeformGradient : BackgroundFill
{
    public override BackgroundFillTypes Type => BackgroundFillTypes.FreeformGradient;

    public required IReadOnlyList<int> Colors { get; init; }
}
