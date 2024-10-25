namespace Telegram.BotAPI.Types.Stickers;

// https://core.telegram.org/bots/api#maskposition
public sealed class MaskPosition
{
    public string Point { get; set; }

    public float XShift { get; set; }

    public float YShift { get; set; }

    public float Scale { get; set; }

    public static class Points
    {
        public const string FOREHEAD = "forehead";

        public const string EYES = "eyes";

        public const string MOUTH = "mouth";

        public const string CHIN = "chin";
    }
}
