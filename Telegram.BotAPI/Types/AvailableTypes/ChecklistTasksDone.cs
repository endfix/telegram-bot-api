using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class ChecklistTasksDone
{
    public Message? ChecklistMessage { get; init; }

    public IReadOnlyList<int>? MarkedAsDoneTaskIds { get; init; }

    public IReadOnlyList<int>? MarkedAsNotDoneTaskIds { get; init; }
}
