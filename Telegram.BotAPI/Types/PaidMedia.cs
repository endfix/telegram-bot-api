using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#paidmedia
public abstract class PaidMedia
{
    public abstract string Type { get; }

    public static class Types
    {
        public const string PREVIEW = "preview";

        public const string PHOTO = "photo";

        public const string VIDEO = "video";
    }
}

// https://core.telegram.org/bots/api#paidmediaphoto
public sealed class PaidMediaPhoto : PaidMedia
{
    public override string Type => Types.PHOTO;

    public List<PhotoSize> Photo { get; set; }
}

// https://core.telegram.org/bots/api#paidmediapreview
public sealed class PaidMediaPreview : PaidMedia
{
    public override string Type => Types.PREVIEW;

    public int Width { get; set; }

    public int Height { get; set; }

    public int Duration { get; set; }
}

// https://core.telegram.org/bots/api#paidmediavideo
public sealed class PaidMediaVideo : PaidMedia
{
    public override string Type => Types.VIDEO;

    public Video Video { get; set; }
}
