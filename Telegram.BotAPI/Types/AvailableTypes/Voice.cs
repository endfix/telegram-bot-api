namespace Telegram.BotAPI.Types;

public sealed class Voice
{
    public required string FileId { get; init; }

    public required string FileUniqueId { get; init; }

    public required int Duration { get; init; }

    public string? MimeType { get; init; }

    public int? FileSize { get; init; }
}
