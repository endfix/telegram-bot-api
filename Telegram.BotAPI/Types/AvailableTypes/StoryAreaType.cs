using System;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class StoryAreaType
{
    public abstract StoryAreaTypes Type { get; }
}

public sealed class StoryAreaTypeLocation : StoryAreaType
{
    public override StoryAreaTypes Type => StoryAreaTypes.Location;

    public float Latitude { get; set; }

    public float Longitude { get; set; }

    public LocationAddress Address { get; set; }
}

public sealed class StoryAreaTypeSuggestedReaction : StoryAreaType
{
    public override StoryAreaTypes Type => StoryAreaTypes.SuggestedReaction;

    public ReactionType ReactionType { get; set; }

    public bool IsDark { get; set; }

    public bool IsFlipped { get; set; }
}

public sealed class StoryAreaTypeLink : StoryAreaType
{
    public override StoryAreaTypes Type => StoryAreaTypes.Link;

    public string Url { get; set; }
}

public sealed class StoryAreaTypeWeather : StoryAreaType
{
    public override StoryAreaTypes Type => StoryAreaTypes.Weather;

    public float Temperature { get; set; }

    public string Emoji { get; set; }

    public int BackgroundColor { get; set; }
}

public sealed class StoryAreaTypeUniqueGift : StoryAreaType
{
    public override StoryAreaTypes Type => StoryAreaTypes.UniqueGift;

    public string Name { get; set; }
}
