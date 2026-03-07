using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class InputPaidMedia
{
    public abstract InputPaidMediaTypes Type { get; }

    public required virtual string Media { get; init; }
}

public sealed class InputPaidMediaPhoto : InputPaidMedia
{
    public override InputPaidMediaTypes Type => InputPaidMediaTypes.Photo;
}

public sealed class InputPaidMediaVideo : InputPaidMedia
{
    public override InputPaidMediaTypes Type => InputPaidMediaTypes.Video;

    public object? Thumbnail { get; init; }

    public string? Cover { get; init; }

    public int? StartTimestamp { get; init; }

    public int? Width { get; init; }

    public int? Height { get; init; }

    public int? Duration { get; init; }

    public bool? SupportsStreaming { get; init; }
}
