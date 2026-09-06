using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>forwardMessage</c> method.
/// </summary>
public sealed class ForwardMessageParameters : ApiRequestParameters
{
    /// <summary>Destination chat.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target message thread.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Topic identifier in a direct messages chat.</summary>
    public long? DirectMessagesTopicId { get; init; }

    /// <summary>Source chat.</summary>
    public required ChatIdSource FromChatId { get; init; }

    /// <summary>Start timestamp for forwarded video messages.</summary>
    public int? VideoStartTimestamp { get; init; }

    /// <summary>Sends the message silently when <see langword="true"/>.</summary>
    public bool? DisableNotification { get; init; }

    /// <summary>Protects the message from forwarding and saving when <see langword="true"/>.</summary>
    public bool? ProtectContent { get; init; }

    /// <summary>Parameters for a suggested post.</summary>
    public SuggestedPostParameters? SuggestedPostParameters { get; init; }

    /// <summary>Identifier of the message to forward.</summary>
    public required long MessageId { get; init; }
}
