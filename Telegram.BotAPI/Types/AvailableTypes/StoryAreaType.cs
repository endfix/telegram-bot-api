using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public abstract class StoryAreaType
{
    public abstract StoryAreaTypes Type { get; }
}

public sealed class StoryAreaTypeLocation : StoryAreaType
{
    public override StoryAreaTypes Type => StoryAreaTypes.Location;

    public required double Latitude { get; init; }

    public required double Longitude { get; init; }

    public LocationAddress? Address { get; init; }
}

public sealed class StoryAreaTypeSuggestedReaction : StoryAreaType
{
    public override StoryAreaTypes Type => StoryAreaTypes.SuggestedReaction;

    public required ReactionType ReactionType { get; init; }

    public bool? IsDark { get; init; }

    public bool? IsFlipped { get; init; }
}

public sealed class StoryAreaTypeLink : StoryAreaType
{
    public override StoryAreaTypes Type => StoryAreaTypes.Link;

    public required string Url { get; init; }
}

public sealed class StoryAreaTypeWeather : StoryAreaType
{
    public override StoryAreaTypes Type => StoryAreaTypes.Weather;

    public required float Temperature { get; init; }

    public required string Emoji { get; init; }

    public required int BackgroundColor { get; init; }
}

public sealed class StoryAreaTypeUniqueGift : StoryAreaType
{
    public override StoryAreaTypes Type => StoryAreaTypes.UniqueGift;

    public required string Name { get; init; }
}
