using System.Collections.Generic;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class PaidMedia
{
    public abstract PaidMediaType Type { get; }
}

public sealed class PaidMediaPhoto : PaidMedia
{
    public override PaidMediaType Type => PaidMediaType.Photo;

    public required IReadOnlyList<PhotoSize> Photo { get; init; }
}

public sealed class PaidMediaPreview : PaidMedia
{
    public override PaidMediaType Type => PaidMediaType.Preview;

    public int? Width { get; init; }

    public int? Height { get; init; }

    public int? Duration { get; init; }
}

public sealed class PaidMediaVideo : PaidMedia
{
    public override PaidMediaType Type => PaidMediaType.Video;

    public required Video Video { get; init; }
}
