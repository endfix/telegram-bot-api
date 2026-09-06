namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a media element embedded in an outgoing rich message.</summary>
public sealed class InputRichMessageMedia
{
    /// <summary>Unique identifier of the media referenced by a Telegram media link; 1-64 characters, using only letters, digits, underscores and hyphens.</summary>
    public required string Id { get; init; }

    /// <summary>Media to be sent.</summary>
    public required InputMedia Media { get; init; }
}
