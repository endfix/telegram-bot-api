using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class PollMedia
{
    public Animation? Animation { get; init; }

    public Audio? Audio { get; init; }

    public Document? Document { get; init; }

    public Link? Link { get; init; }

    public LivePhoto? LivePhoto { get; init; }

    public Location? Location { get; init; }

    public IReadOnlyList<PhotoSize>? Photo { get; init; }

    public Sticker? Sticker { get; init; }

    public Venue? Venue { get; init; }

    public Video? Video { get; init; }
}
