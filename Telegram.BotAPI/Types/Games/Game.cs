using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class Game
{
    public required string Title { get; init; }

    public required string Description { get; init; }

    public required IReadOnlyList<PhotoSize> Photo { get; init; }

    public string? Text { get; init; }

    public IReadOnlyList<MessageEntity>? TextEntities { get; init; }

    public Animation? Animation { get; init; }
}
