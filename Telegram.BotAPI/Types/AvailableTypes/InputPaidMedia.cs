using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class InputPaidMedia
{
    public abstract InputPaidMediaTypes Type { get; }

    public virtual string Media { get; set; }
}

public sealed class InputPaidMediaPhoto : InputPaidMedia
{
    public override InputPaidMediaTypes Type => InputPaidMediaTypes.Photo;
}

public sealed class InputPaidMediaVideo : InputPaidMedia
{
    public override InputPaidMediaTypes Type => InputPaidMediaTypes.Video;

    public object Thumbnail { get; set; }

    public string Cover { get; set; }

    public int StartTimestamp { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public int Duration { get; set; }

    public bool SupportsStreaming { get; set; }
}
