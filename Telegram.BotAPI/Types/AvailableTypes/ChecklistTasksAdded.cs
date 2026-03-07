using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class ChecklistTasksAdded
{
    public required Message ChecklistMessage { get; init; }

    public required IReadOnlyList<ChecklistTask> Tasks { get; init; }
}
