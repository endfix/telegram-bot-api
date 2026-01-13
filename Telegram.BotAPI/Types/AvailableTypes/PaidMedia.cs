using System.Collections.Generic;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(PaidMediaPhoto), "photo")]
[JsonDerivedType(typeof(PaidMediaPreview), "preview")]
[JsonDerivedType(typeof(PaidMediaVideo), "video")]
public abstract class PaidMedia
{
    [JsonIgnore]
    public abstract PaidMediaTypes Type { get; }
}

public sealed class PaidMediaPhoto : PaidMedia
{
    public override PaidMediaTypes Type => PaidMediaTypes.Photo;

    public required IReadOnlyList<PhotoSize> Photo { get; init; }
}

public sealed class PaidMediaPreview : PaidMedia
{
    public override PaidMediaTypes Type => PaidMediaTypes.Preview;

    public int? Width { get; init; }

    public int? Height { get; init; }

    public int? Duration { get; init; }
}

public sealed class PaidMediaVideo : PaidMedia
{
    public override PaidMediaTypes Type => PaidMediaTypes.Video;

    public required Video Video { get; init; }
}
