namespace Telegram.BotAPI.Types;

public sealed class InputPollOption
{
    public string Text { get; set; }

    public string TextParseMode { get; set; }

    public MessageEntity[] TextEntities { get; set; }
}
