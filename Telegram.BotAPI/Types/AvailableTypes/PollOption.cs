namespace Telegram.BotAPI.Types;

public sealed class PollOption
{
    public string Text { get; set; }

    public MessageEntity[] TextEntities { get; set; }

    public int VoterCount { get; set; }
}
