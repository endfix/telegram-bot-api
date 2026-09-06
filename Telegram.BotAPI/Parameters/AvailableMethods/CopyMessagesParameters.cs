using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>copyMessages</c> method.
/// </summary>
public sealed class CopyMessagesParameters : ApiRequestParameters
{
    /// <summary>Destination chat.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target message thread.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Topic identifier in a direct messages chat.</summary>
    public long? DirectMessagesTopicId { get; init; }

    /// <summary>Source chat.</summary>
    public required ChatIdSource FromChatId { get; init; }

    /// <summary>Identifiers of the messages to copy.</summary>
    public required IReadOnlyList<long> MessageIds { get; init; }

    /// <summary>Sends the messages silently when <see langword="true"/>.</summary>
    public bool? DisableNotification { get; init; }

    /// <summary>Protects the messages from forwarding and saving when <see langword="true"/>.</summary>
    public bool? ProtectContent { get; init; }

    /// <summary>Whether to remove captions from copied messages.</summary>
    public bool? RemoveCaption { get; init; }
}
