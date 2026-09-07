using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendLocation</c> method.
/// </summary>
public sealed class SendLocationParameters : ApiRequestParameters
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

    /// <summary>Latitude of the location.</summary>
    public required double Latitude { get; init; }

    /// <summary>Longitude of the location.</summary>
    public required double Longitude { get; init; }

    /// <summary>Radius of location uncertainty in meters, from 0 through 1500.</summary>
    public float? HorizontalAccuracy { get; init; }

    /// <summary>Period in seconds during which the location can be updated, from 60 through 86400, or <see cref="int.MaxValue"/> for an indefinitely editable location. Must be 0 for ephemeral messages.</summary>
    public int? LivePeriod { get; init; }

    /// <summary>Direction of movement in degrees, from 1 through 360.</summary>
    public int? Heading { get; init; }

    /// <summary>Maximum proximity-alert distance in meters, from 1 through 100000.</summary>
    public int? ProximityAlertRadius { get; init; }

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
