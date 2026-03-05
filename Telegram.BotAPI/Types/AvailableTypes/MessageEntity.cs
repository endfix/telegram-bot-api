namespace Telegram.BotAPI.Types;

public sealed class MessageEntity
{
    public required string Type { get; init; }

    public required int Offset { get; init; }

    public required int Length { get; init; }

    public string? Url { get; init; }

    public User? User { get; init; }

    public string? Language { get; init; }

    public string? CustomEmojiId { get; init; }

    public int? UnixTime { get; init; }

    public string? DateTimeFormat { get; init; }
}
