namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a service message about a chat or bot being added to a community.</summary>
public sealed class CommunityChatAdded
{
    /// <summary>The new community to which the chat or bot belongs.</summary>
    public required Community Community { get; init; }
}
