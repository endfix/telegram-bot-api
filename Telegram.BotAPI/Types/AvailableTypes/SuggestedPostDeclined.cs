namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a service message about a declined suggested post.</summary>
public sealed class SuggestedPostDeclined
{
    /// <summary>Message containing the suggested post, if available.</summary>
    public Message? SuggestedPostMessage { get; init; }

    /// <summary>Comment explaining the decline, if available.</summary>
    public string? Comment { get; init; }
}
