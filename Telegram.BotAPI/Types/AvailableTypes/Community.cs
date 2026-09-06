namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a community, which is a group of linked chats.</summary>
public sealed class Community
{
    /// <summary>Unique identifier of the community.</summary>
    public required long Id { get; set; }

    /// <summary>Name of the community.</summary>
    public required string Name { get; set; }
}
