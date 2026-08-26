using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class LivePhoto
{
    public IReadOnlyList<PhotoSize>? Photo { get; init; }

    public required string FileId { get; init; }

    public required string FileUniqueId { get; init; }

    public required int Width { get; init; }

    public required int Height { get; init; }

    public required int Duration { get; init; }

    public string? MimeType { get; init; }

    public int? FileSize { get; init; }
}
