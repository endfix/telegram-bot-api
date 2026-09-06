using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes the type of a clickable area on a story.
/// </summary>
public abstract class StoryAreaType
{
    /// <summary>
    /// Gets the type of the area.
    /// </summary>
    public abstract StoryAreaTypes Type { get; }
}

/// <summary>
/// Describes a story area pointing to a location.
/// </summary>
public sealed class StoryAreaTypeLocation : StoryAreaType
{
    /// <inheritdoc />
    public override StoryAreaTypes Type => StoryAreaTypes.Location;

    /// <summary>
    /// The location latitude in degrees.
    /// </summary>
    public required double Latitude { get; init; }

    /// <summary>
    /// The location longitude in degrees.
    /// </summary>
    public required double Longitude { get; init; }

    /// <summary>
    /// Optional address of the location.
    /// </summary>
    public LocationAddress? Address { get; init; }
}

/// <summary>
/// Describes a story area pointing to a suggested reaction.
/// </summary>
public sealed class StoryAreaTypeSuggestedReaction : StoryAreaType
{
    /// <inheritdoc />
    public override StoryAreaTypes Type => StoryAreaTypes.SuggestedReaction;

    /// <summary>
    /// The type of the reaction.
    /// </summary>
    public required ReactionType ReactionType { get; init; }

    /// <summary>
    /// Pass true if the reaction area has a dark background.
    /// </summary>
    public bool? IsDark { get; init; }

    /// <summary>
    /// Pass true if the reaction area corner is flipped.
    /// </summary>
    public bool? IsFlipped { get; init; }
}

/// <summary>
/// Describes a story area pointing to an HTTP or tg:// link.
/// </summary>
public sealed class StoryAreaTypeLink : StoryAreaType
{
    /// <inheritdoc />
    public override StoryAreaTypes Type => StoryAreaTypes.Link;

    /// <summary>
    /// The HTTP or tg:// URL to be opened when the area is clicked.
    /// </summary>
    public required string Url { get; init; }
}

/// <summary>
/// Describes a story area containing weather information.
/// </summary>
public sealed class StoryAreaTypeWeather : StoryAreaType
{
    /// <inheritdoc />
    public override StoryAreaTypes Type => StoryAreaTypes.Weather;

    /// <summary>
    /// The temperature in degrees Celsius.
    /// </summary>
    public required float Temperature { get; init; }

    /// <summary>
    /// The emoji representing the weather.
    /// </summary>
    public required string Emoji { get; init; }

    /// <summary>
    /// The color of the area background in the ARGB format.
    /// </summary>
    public required int BackgroundColor { get; init; }
}

/// <summary>
/// Describes a story area pointing to a unique gift.
/// </summary>
public sealed class StoryAreaTypeUniqueGift : StoryAreaType
{
    /// <inheritdoc />
    public override StoryAreaTypes Type => StoryAreaTypes.UniqueGift;

    /// <summary>
    /// The unique name of the gift.
    /// </summary>
    public required string Name { get; init; }
}
