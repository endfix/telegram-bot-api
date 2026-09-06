namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a chat photo.</summary>
public sealed class ChatPhoto
{
    /// <summary>Identifier of the small chat photo file.</summary>
    public required string SmallFileId { get; init; }

    /// <summary>Unique identifier of the small chat photo file.</summary>
    public required string SmallFileUniqueId { get; init; }

    /// <summary>Identifier of the big chat photo file.</summary>
    public required string BigFileId { get; init; }

    /// <summary>Unique identifier of the big chat photo file.</summary>
    public required string BigFileUniqueId { get; init; }
}
