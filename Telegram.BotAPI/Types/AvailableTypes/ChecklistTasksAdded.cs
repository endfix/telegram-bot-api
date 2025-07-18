namespace Telegram.BotAPI.Types;

public sealed class ChecklistTasksAdded
{
    public Message ChecklistMessage { get; set; }

    public ChecklistTask[] Tasks { get; set; }
}
