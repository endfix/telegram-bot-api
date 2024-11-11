namespace Telegram.BotAPI.Types.AvailableTypes;

public abstract class InputPaidMedia
{
    public abstract string Type { get; }

    public virtual string Media { get; set; }

    public static class Types
    {
        public const string PHOTO = "photo";

        public const string VIDEO = "video";
    }
}

public sealed class InputPaidMediaPhoto : InputPaidMedia
{
    public override string Type => Types.PHOTO;
}

public sealed class InputPaidMediaVideo : InputPaidMedia
{
    public override string Type => Types.VIDEO;

    // thumbnail

    public int Width { get; set; }

    public int Height { get; set; }

    public int Duration { get; set; }

    public bool SupportsStreaming { get; set; }
}
