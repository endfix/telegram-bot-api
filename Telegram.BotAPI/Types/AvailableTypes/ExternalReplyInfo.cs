using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains information about a message being replied to from another chat or forum topic.</summary>
public sealed class ExternalReplyInfo
{
    /// <summary>Origin of the original message.</summary>
    public required MessageOrigin Origin { get; init; }

    /// <summary>Chat to which the original message belongs, if available.</summary>
    public Chat? Chat { get; init; }

    /// <summary>Unique identifier of the original message, if available.</summary>
    public long? MessageId { get; init; }

    /// <summary>Link preview options used by the original message, if available.</summary>
    public LinkPreviewOptions? LinkRreviewOptions { get; init; }

    public Animation? Animation { get; init; }

    public Audio? Audio { get; init; }

    public Document? Document { get; init; }

    public LivePhoto? LivePhoto { get; init; }

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
