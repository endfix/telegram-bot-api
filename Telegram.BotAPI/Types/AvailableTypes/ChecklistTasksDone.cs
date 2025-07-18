namespace Telegram.BotAPI.Types;

public sealed class ChecklistTasksDone
{
    public Message ChecklistMessage { get; set; }

    public int[] MarkedAsDoneTaskIds { get; set; }

    public int[] MarkedAsNotDoneTaskIds { get; set; }
}
