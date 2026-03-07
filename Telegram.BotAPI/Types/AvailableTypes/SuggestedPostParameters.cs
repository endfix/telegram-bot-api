namespace Telegram.BotAPI.Types;

public sealed class SuggestedPostParameters
{
    public SuggestedPostPrice? Price { get; init; }

    public int? SendDate { get; init; }
}