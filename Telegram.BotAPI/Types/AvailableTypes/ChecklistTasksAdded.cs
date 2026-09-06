using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a service message about tasks added to a checklist.</summary>
public sealed class ChecklistTasksAdded
{
    /// <summary>Message containing the checklist to which the tasks were added.</summary>
    public required Message ChecklistMessage { get; init; }

    /// <summary>Tasks added to the checklist.</summary>
    public required IReadOnlyList<ChecklistTask> Tasks { get; init; }
}
