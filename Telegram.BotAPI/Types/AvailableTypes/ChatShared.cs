using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class ChatShared
{
    public required int RequestId { get; init; }

    public required long ChatId { get; init; }

    public string? Title { get; init; }

    public string? Username { get; init; }

    public IReadOnlyList<PhotoSize>? Photo { get; init; }
}
