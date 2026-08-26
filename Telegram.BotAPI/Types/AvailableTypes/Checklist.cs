using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class Checklist
{
    public required string Title { get; init; }

    public IReadOnlyList<MessageEntity>? TitleEntities { get; init; }

    public required IReadOnlyList<ChecklistTask> Tasks { get; init; }

    public bool? OthersCanAddTasks { get; init; }

    public bool? OthersCanMarkTasksAsDone { get; init; }
}
