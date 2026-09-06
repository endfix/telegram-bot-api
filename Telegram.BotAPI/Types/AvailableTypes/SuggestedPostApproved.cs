namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a service message about an approved suggested post.</summary>
public sealed class SuggestedPostApproved
{
    /// <summary>Message containing the suggested post, if available.</summary>
    public Message? SuggestedPostMessage { get; init; }

    /// <summary>Price associated with the suggested post, if available.</summary>
    public SuggestedPostPrice? Price { get; init; }

    /// <summary>Scheduled send date in Unix time.</summary>
    public required int SendDate { get; init; }
}
