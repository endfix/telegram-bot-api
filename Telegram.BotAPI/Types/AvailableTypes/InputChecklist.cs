using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a checklist to create.</summary>
public sealed class InputChecklist
{
    /// <summary>Title of the checklist; 1-255 characters after entity parsing.</summary>
    public required string Title { get; init; }

    /// <summary>Optional. Mode for parsing entities in the title.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Optional. Special entities in the title, specified instead of <see cref="ParseMode"/>. Only bold, italic, underline, strikethrough, spoiler, custom emoji and date-time entities are allowed.</summary>
    public IReadOnlyList<MessageEntity>? TitleEntities { get; init; }

    /// <summary>List of 1-30 tasks in the checklist.</summary>
    public required IReadOnlyList<InputChecklistTask> Tasks { get; init; }

    /// <summary>Optional. Pass <see langword="true"/> if other users can add tasks.</summary>
    public bool? OthersCanAddTasks { get; init; }

    /// <summary>Optional. Pass <see langword="true"/> if other users can mark tasks as done or not done.</summary>
    public bool? OthersCanMarkTasksAsDone { get; init; }
}
