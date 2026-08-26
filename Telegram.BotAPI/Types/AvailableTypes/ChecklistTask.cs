using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class ChecklistTask
{
    public required int Id { get; init; }

    public required string Text { get; init; }

    public IReadOnlyList<MessageEntity>? TextEntities { get; init; }

    public User? CompletedByUser { get; init; }

    public Chat? CompletedByChat { get; init; }

    public int? CompletionDate { get; init; }
}
