using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#backgroundfill
public abstract class BackgroundFill
{
    public virtual string Type { get; set; }

    public static class Types
    {
        public const string SOLID = "solid";

        public const string GRADIENT = "gradient";

        public const string FREEFORM_GRADIENT = "freeform_gradient";
    }
}

// https://core.telegram.org/bots/api#backgroundfillfreeformgradient
public sealed class BackgroundFillFreeformGradient : BackgroundFill
{
    public override string Type => Types.FREEFORM_GRADIENT;

    public List<int> Colors { get; set; }
}

// https://core.telegram.org/bots/api#backgroundfillgradient
public sealed class BackgroundFillGradient : BackgroundFill
{
    public override string Type => Types.GRADIENT;

    public string TopColor { get; set; }

    public string BottomColor { get; set; }

    public string RotationAngle { get; set; }
}

// https://core.telegram.org/bots/api#backgroundfillsolid
public sealed class BackgroundFillSolid : BackgroundFill
{
    public override string Type => Types.SOLID;

    public int Color { get; set; }
}
