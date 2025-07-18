namespace Telegram.BotAPI.Types;

public sealed class Checklist
{
    public string Title { get; set; }

    public MessageEntity[] TitleEntities { get; set; }

    public ChecklistTask[] Tasks { get; set; }

    public bool OthersCanAddTasks { get; set; }

    public bool OthersCanMarkTasksAsDone { get; set; }

}
