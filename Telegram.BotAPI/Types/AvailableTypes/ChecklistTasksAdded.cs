using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class ChecklistTasksAdded
{
    public required Message ChecklistMessage { get; init; }

    public required IReadOnlyList<ChecklistTask> Tasks { get; init; }
}
