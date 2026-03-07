using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class InputChecklistTask
{
    public required int Id { get; init; }

    public required string Text { get; init; }

    public string? ParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? TextEntities { get; init; }
}
