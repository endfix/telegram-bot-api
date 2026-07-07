using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class InputPaidMedia
{
    public abstract InputPaidMediaType Type { get; }

    public required virtual MediaSource Media { get; init; }
}

public sealed class InputPaidMediaLivePhoto : InputPaidMedia
{
    public override InputPaidMediaType Type => InputPaidMediaType.LivePhoto;

    public required MediaSource Photo { get; init; }
}

public sealed class InputPaidMediaPhoto : InputPaidMedia
{
    public override InputPaidMediaType Type => InputPaidMediaType.Photo;
}

public sealed class InputPaidMediaVideo : InputPaidMedia
{
    public override InputPaidMediaType Type => InputPaidMediaType.Video;

    public object? Thumbnail { get; init; }

    public string? Cover { get; init; }

    public int? StartTimestamp { get; init; }

    public int? Width { get; init; }

    public int? Height { get; init; }

    public int? Duration { get; init; }

    public bool? SupportsStreaming { get; init; }
}
