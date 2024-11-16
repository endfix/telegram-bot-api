using System.Collections.Generic;

namespace Telegram.BotAPI.Types.AvailableTypes;

public abstract class BackgroundFill
{
    public abstract string Type { get; }

    public static class Types
    {
        public const string SOLID = "solid";

        public const string GRADIENT = "gradient";

        public const string FREEFORM_GRADIENT = "freeform_gradient";
    }
}

public sealed class BackgroundFillFreeformGradient : BackgroundFill
{
    public override string Type => Types.FREEFORM_GRADIENT;

    public List<int> Colors { get; set; }
}

public sealed class BackgroundFillGradient : BackgroundFill
{
    public override string Type => Types.GRADIENT;

    public string TopColor { get; set; }

    public string BottomColor { get; set; }

    public string RotationAngle { get; set; }
}

public sealed class BackgroundFillSolid : BackgroundFill
{
    public override string Type => Types.SOLID;

    public int Color { get; set; }
}
