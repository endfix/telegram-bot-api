using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a task in a checklist.</summary>
public sealed class ChecklistTask
{
    /// <summary>Unique identifier of the task.</summary>
    public required int Id { get; init; }

    /// <summary>Text of the task.</summary>
    public required string Text { get; init; }

    /// <summary>Optional. Special entities that appear in the task text.</summary>
    public IReadOnlyList<MessageEntity>? TextEntities { get; init; }

    /// <summary>Optional. User that completed the task.</summary>
    public User? CompletedByUser { get; init; }

    /// <summary>Optional. Chat that completed the task.</summary>
    public Chat? CompletedByChat { get; init; }

    /// <summary>Optional. Unix time when the task was completed; 0 if the task was not completed.</summary>
    public int? CompletionDate { get; init; }
}
