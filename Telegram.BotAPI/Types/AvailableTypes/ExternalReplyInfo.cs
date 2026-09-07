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
    public LinkPreviewOptions? LinkPreviewOptions { get; init; }

    /// <summary>Information about the animation when the original message is an animation.</summary>
    public Animation? Animation { get; init; }

    /// <summary>Information about the audio file when the original message is an audio.</summary>
    public Audio? Audio { get; init; }

    /// <summary>Information about the file when the original message is a document.</summary>
    public Document? Document { get; init; }

    /// <summary>Information about the live photo when the original message is a live photo.</summary>
    public LivePhoto? LivePhoto { get; init; }

    /// <summary>Information about paid media contained in the original message.</summary>
    public PaidMediaInfo? PaidMedia { get; init; }

    /// <summary>Available photo sizes when the original message is a photo.</summary>
    public IReadOnlyList<PhotoSize>? Photo { get; init; }

    /// <summary>Information about the sticker when the original message is a sticker.</summary>
    public Sticker? Sticker { get; init; }

    /// <summary>Forwarded story contained in the original message.</summary>
    public Story? Story { get; init; }

    /// <summary>Information about the video when the original message is a video.</summary>
    public Video? Video { get; init; }

    /// <summary>Information about the video note when the original message is a video note.</summary>
    public VideoNote? VideoNote { get; init; }

    /// <summary>Information about the voice file when the original message is a voice message.</summary>
    public Voice? Voice { get; init; }

    /// <summary>Indicates whether the original message media is covered by a spoiler animation.</summary>
    public bool? HasMediaSpoiler { get; init; }

    /// <summary>Checklist contained in the original message.</summary>
    public Checklist? Checklist { get; init; }

    /// <summary>Shared contact contained in the original message.</summary>
    public Contact? Contact { get; init; }

    /// <summary>Dice with a random value contained in the original message.</summary>
    public Dice? Dice { get; init; }

    /// <summary>Game contained in the original message.</summary>
    public Game? Game { get; init; }

    /// <summary>Scheduled giveaway contained in the original message.</summary>
    public Giveaway? Giveaway { get; init; }

    /// <summary>Information about a completed giveaway with public winners.</summary>
    public GiveawayWinners? GiveawayWinners { get; init; }

    /// <summary>Invoice contained in the original message.</summary>
    public Invoice? Invoice { get; init; }

    /// <summary>Shared location contained in the original message.</summary>
    public Location? Location { get; init; }

    /// <summary>Native poll contained in the original message.</summary>
    public Poll? Poll { get; init; }

    /// <summary>Venue contained in the original message.</summary>
    public Venue? Venue { get; init; }
}
