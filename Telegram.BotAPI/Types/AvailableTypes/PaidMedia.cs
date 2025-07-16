using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class PaidMedia
{
    public abstract PaidMediaTypes Type { get; }
}

public sealed class PaidMediaPhoto : PaidMedia
{
    public override PaidMediaTypes Type => PaidMediaTypes.Photo;

    public PhotoSize[] Photo { get; set; }
}

public sealed class PaidMediaPreview : PaidMedia
{
    public override PaidMediaTypes Type => PaidMediaTypes.Preview;

    public int Width { get; set; }

    public int Height { get; set; }

    public int Duration { get; set; }
}

public sealed class PaidMediaVideo : PaidMedia
{
    public override PaidMediaTypes Type => PaidMediaTypes.Video;

    public Video Video { get; set; }
}
