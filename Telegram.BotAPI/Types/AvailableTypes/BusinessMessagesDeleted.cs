using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents messages deleted from a connected business account.</summary>
public sealed class BusinessMessagesDeleted
{
    /// <summary>Unique identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>Chat where the messages were deleted.</summary>
    public required Chat Chat { get; init; }

    /// <summary>Identifiers of the deleted messages.</summary>
    public required IReadOnlyList<long> MessageIds { get; init; }
}
