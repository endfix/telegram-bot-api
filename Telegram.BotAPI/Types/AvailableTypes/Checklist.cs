using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a checklist.</summary>
public sealed class Checklist
{
    /// <summary>Title of the checklist.</summary>
    public required string Title { get; init; }

    /// <summary>Optional. Special entities that appear in the checklist title.</summary>
    public IReadOnlyList<MessageEntity>? TitleEntities { get; init; }

    /// <summary>Tasks in the checklist.</summary>
    public required IReadOnlyList<ChecklistTask> Tasks { get; init; }

    /// <summary>Optional. Indicates whether users other than the creator can add tasks.</summary>
    public bool? OthersCanAddTasks { get; init; }

    /// <summary>Optional. Indicates whether users other than the creator can mark tasks as done or not done.</summary>
    public bool? OthersCanMarkTasksAsDone { get; init; }
}
