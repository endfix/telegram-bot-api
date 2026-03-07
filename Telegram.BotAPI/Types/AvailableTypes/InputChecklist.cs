using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class InputChecklist
{
    public required string Title { get; init; }

    public string? ParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? TitleEntities { get; init; }

    public required IReadOnlyList<InputChecklistTask> Tasks { get; init; }

    public bool? OthersCanAddTasks { get; init; }

    public bool? OthersCanMarkTasksAsDone { get; init; }
}
