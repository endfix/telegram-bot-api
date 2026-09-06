namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a service message about a chat being joined by a user from a community.</summary>
public sealed class CommunityChatJoined
{
    /// <summary>The community from which the chat was joined.</summary>
    public required Community Community { get; init; }
}
