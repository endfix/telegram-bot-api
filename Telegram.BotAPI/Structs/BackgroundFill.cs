namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#backgroundfill
    public abstract class BackgroundFill
    {
        public virtual string Type { get; set; }

        public class Types
        {
            public const string SOLID = "solid";

            public const string GRADIENT = "gradient";

            public const string FREEFORM_GRADIENT = "freeform_gradient";
        }

        // https://core.telegram.org/bots/api#backgroundfillsolid
        public sealed class SolidStruct : BackgroundFill
        {
            public override string Type => Types.SOLID;

            public int Color { get; set; }
        }

        // https://core.telegram.org/bots/api#backgroundfillgradient
        public sealed class GradientStruct : BackgroundFill
        {
            public override string Type => Types.GRADIENT;

            public string TopColor { get; set; }

            public string BottomColor { get; set; }

            public string RotationAngle { get; set; }
        }

        // https://core.telegram.org/bots/api#backgroundfillfreeformgradient
        public sealed class FreeformGradientStruct : BackgroundFill
        {
            public override string Type => Types.FREEFORM_GRADIENT;

            public List<int> Colors { get; set; }
        }
    }
}
