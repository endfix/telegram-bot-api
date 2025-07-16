namespace Telegram.BotAPI.Types;

public sealed class UniqueGiftSymbol
{
    public string Name { get; set; }

    public Sticker Sticker { get; set; }

    public int RarityPerMille { get; set; }
}
