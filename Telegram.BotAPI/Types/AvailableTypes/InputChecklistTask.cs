using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a task to add to a checklist.</summary>
public sealed class InputChecklistTask
{
    /// <summary>Unique positive task identifier, unique among the tasks currently present in the checklist.</summary>
    public required int Id { get; init; }

    /// <summary>Text of the task; 1-100 characters after entity parsing.</summary>
    public required string Text { get; init; }

    /// <summary>Mode for parsing entities in the task text.</summary>
    public ParseMode? ParseMode { get; init; }

    /// <summary>Special entities in the task text; can be specified instead of <see cref="ParseMode"/>. Only bold, italic, underline, strikethrough, spoiler, custom emoji and date-time entities are allowed.</summary>
    public IReadOnlyList<MessageEntity>? TextEntities { get; init; }
}
