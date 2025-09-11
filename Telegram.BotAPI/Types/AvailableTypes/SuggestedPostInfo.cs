namespace Telegram.BotAPI.Types;

public sealed class SuggestedPostInfo
{
    public string State { get; set; }

    public SuggestedPostPrice Price { get; set; }

    public int SendDate { get; set; }
}
