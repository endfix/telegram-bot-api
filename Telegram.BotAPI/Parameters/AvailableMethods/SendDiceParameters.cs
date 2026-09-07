using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendDice</c> method.
/// </summary>
public sealed class SendDiceParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection on whose behalf the message is sent.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Target chat identifier or username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target message thread identifier.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Direct messages topic identifier; required for a direct messages chat.</summary>
    public long? DirectMessagesTopicId { get; init; }

    /// <summary>Emoji on which the dice animation is based. Defaults to the standard die emoji.</summary>
    public string? Emoji { get; init; }

    /// <summary>Whether to send the message silently.</summary>
    public bool? DisableNotification { get; init; }

    /// <summary>Whether to protect the message from forwarding.</summary>
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
