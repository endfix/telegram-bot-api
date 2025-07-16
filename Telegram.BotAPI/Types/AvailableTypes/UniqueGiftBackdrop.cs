namespace Telegram.BotAPI.Types;

public sealed class UniqueGiftBackdrop
{
    public string Name { get; set; }

    public UniqueGiftBackdropColors Colors { get; set; }

    public int RarityPerMille { get; set; }
}
