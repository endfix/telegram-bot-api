namespace Telegram.BotAPI.Types;

public sealed class ChecklistTask
{
    public int Id { get; set; }

    public string Text { get; set; }

    public MessageEntity[] TextEntities { get; set; }

    public User CompletedByUser { get; set; }

    public int CompletionDate { get; set; }
}
