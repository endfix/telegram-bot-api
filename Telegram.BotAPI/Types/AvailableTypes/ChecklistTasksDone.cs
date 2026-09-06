using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a service message about checklist tasks marked as done or not done.</summary>
public sealed class ChecklistTasksDone
{
    /// <summary>Optional. Message containing the checklist whose tasks were changed.</summary>
    public Message? ChecklistMessage { get; init; }

    /// <summary>Optional. Identifiers of tasks marked as done.</summary>
    public IReadOnlyList<int>? MarkedAsDoneTaskIds { get; init; }

    /// <summary>Optional. Identifiers of tasks marked as not done.</summary>
    public IReadOnlyList<int>? MarkedAsNotDoneTaskIds { get; init; }
}
