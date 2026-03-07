using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class ExternalReplyInfo
{
    public required MessageOrigin Origin { get; init; }

    public Chat? Chat { get; init; }

    public long? MessageId { get; init; }

    public LinkPreviewOptions? LinkRreviewOptions { get; init; }

    public Animation? Animation { get; init; }

    public Audio? Audio { get; init; }

    public Document? Document { get; init; }

    public PaidMediaInfo? PaidMedia { get; init; }

    public IReadOnlyList<PhotoSize>? Photo { get; init; }

    public Sticker? Sticker { get; init; }

    public Story? Story { get; init; }

    public Video? Video { get; init; }

    public VideoNote? VideoNote { get; init; }

    public Voice? Voice { get; init; }

    public bool? HasMediaSpoiler { get; init; }

    public Checklist? Checklist { get; init; }

    public Contact? Contact { get; init; }

    public Dice? Dice { get; init; }

    public Game? Game { get; init; }

    public Giveaway? Giveaway { get; init; }

    public GiveawayWinners? GiveawayWinners { get; init; }

    public Invoice? Invoice { get; init; }

    public Location? Location { get; init; }

    public Poll? Poll { get; init; }

    public Venue? Venue { get; init; }
}
