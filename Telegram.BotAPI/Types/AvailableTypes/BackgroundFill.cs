using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class BackgroundFill
{
    public abstract BackgroundFillTypes Type { get; }
}

public sealed class BackgroundFillFreeformGradient : BackgroundFill
{
    public override BackgroundFillTypes Type => BackgroundFillTypes.FreeformGradient;

    public int[] Colors { get; set; }
}

public sealed class BackgroundFillGradient : BackgroundFill
{
    public override BackgroundFillTypes Type => BackgroundFillTypes.Gradient;

    public string TopColor { get; set; }

    public string BottomColor { get; set; }

    public string RotationAngle { get; set; }
}

public sealed class BackgroundFillSolid : BackgroundFill
{
    public override BackgroundFillTypes Type => BackgroundFillTypes.Solid;

    public int Color { get; set; }
}
