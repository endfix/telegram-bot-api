namespace Telegram.BotAPI.Types;

public sealed class InputChecklist
{
    public string Title { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] TitleEntities { get; set; }

    public InputChecklistTask[] Tasks { get; set; }

    public bool OthersCanAddTasks { get; set; }

    public bool OthersCanMarkTasksAsDone { get; set; }
}
