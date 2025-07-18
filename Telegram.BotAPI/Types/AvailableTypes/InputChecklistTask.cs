namespace Telegram.BotAPI.Types;

public sealed class InputChecklistTask
{
    public int Id { get; set; }

    public string Text { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] TextEntities { get; set; }
}
