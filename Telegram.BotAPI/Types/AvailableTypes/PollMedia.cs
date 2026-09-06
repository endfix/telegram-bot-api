using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes media attached to a poll or poll option.</summary>
public sealed class PollMedia
{
    /// <summary>Animation media, if present.</summary>
    public Animation? Animation { get; init; }

    /// <summary>Audio media, if present.</summary>
    public Audio? Audio { get; init; }

    /// <summary>Document media, if present.</summary>
    public Document? Document { get; init; }

    /// <summary>Link media, if present.</summary>
    public Link? Link { get; init; }

    /// <summary>Live photo media, if present.</summary>
    public LivePhoto? LivePhoto { get; init; }

    /// <summary>Location media, if present.</summary>
    public Location? Location { get; init; }

    /// <summary>Photo media, if present.</summary>
    public IReadOnlyList<PhotoSize>? Photo { get; init; }

    /// <summary>Sticker media, if present.</summary>
    public Sticker? Sticker { get; init; }

    /// <summary>Venue media, if present.</summary>
    public Venue? Venue { get; init; }

    /// <summary>Video media, if present.</summary>
    public Video? Video { get; init; }
}
