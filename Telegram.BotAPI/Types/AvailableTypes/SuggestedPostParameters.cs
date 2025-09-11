namespace Telegram.BotAPI.Types;

public sealed class SuggestedPostParameters
{
    public SuggestedPostPrice Price { get; set; }

    public int SendDate { get; set; }
}