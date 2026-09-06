using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents one special entity in a text or caption, such as a URL, mention or formatting span.</summary>
public sealed class MessageEntity
{
    /// <summary>Type of the entity.</summary>
    public required MessageEntityType Type { get; init; }

    /// <summary>Offset of the entity in UTF-16 code units.</summary>
    public required int Offset { get; init; }

    /// <summary>Length of the entity in UTF-16 code units.</summary>
    public required int Length { get; init; }

    /// <summary>URL for a text link entity, if applicable.</summary>
    public string? Url { get; init; }

    /// <summary>User mentioned by a text mention entity, if applicable.</summary>
    public User? User { get; init; }

    /// <summary>Language of a pre entity, if applicable.</summary>
    public string? Language { get; init; }

    /// <summary>Identifier of a custom emoji, if applicable.</summary>
    public string? CustomEmojiId { get; init; }

    /// <summary>Unix time represented by a date-time entity, if applicable.</summary>
    public int? UnixTime { get; init; }

    /// <summary>Date-time format used by a date-time entity, if applicable.</summary>
    public string? DateTimeFormat { get; init; }
}
