using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendVenue</c> method.
/// </summary>
public sealed class SendVenueParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection on whose behalf the message is sent.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Target chat identifier or username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target message thread identifier.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Direct messages topic identifier; required for a direct messages chat.</summary>
    public long? DirectMessagesTopicId { get; init; }

    /// <summary>Parameters of the ephemeral message to send.</summary>
    public EphemeralMessageParameters? EphemeralMessageParameters { get; init; }

    /// <summary>Latitude of the venue.</summary>
    public required double Latitude { get; init; }

    /// <summary>Longitude of the venue.</summary>
    public required double Longitude { get; init; }

    /// <summary>Name of the venue.</summary>
    public required string Title { get; init; }

    /// <summary>Address of the venue.</summary>
    public required string Address { get; init; }

    /// <summary>Foursquare identifier of the venue.</summary>
    public string? FoursquareId { get; init; }

    /// <summary>Foursquare type of the venue, if known.</summary>
    public string? FoursquareType { get; init; }

    /// <summary>Google Places identifier of the venue.</summary>
    public string? GooglePlaceId { get; init; }

    /// <summary>Google Places type of the venue.</summary>
    public string? GooglePlaceType { get; init; }

    /// <summary>Whether to send the message silently.</summary>
    public bool? DisableNotification { get; init; }

    /// <summary>Whether to protect the message from forwarding and saving.</summary>
    public bool? ProtectContent { get; init; }

    /// <summary>Whether to allow paid high-throughput broadcasting.</summary>
    public bool? AllowPaidBroadcast { get; init; }

    /// <summary>Message effect identifier; for private chats only.</summary>
    public string? MessageEffectId { get; init; }

    /// <summary>Parameters of the suggested post; for direct messages chats only.</summary>
    public SuggestedPostParameters? SuggestedPostParameters { get; init; }

    /// <summary>Description of the message to reply to.</summary>
    public ReplyParameters? ReplyParameters { get; init; }

    /// <summary>Additional interface options for the message.</summary>
    public ReplyMarkup? ReplyMarkup { get; init; }
}
