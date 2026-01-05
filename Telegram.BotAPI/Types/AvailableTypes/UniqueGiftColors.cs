namespace Telegram.BotAPI.Types;

public sealed class UniqueGiftColors
{
    public string ModelCustomEmojiId { get; set; }

    public string SymbolCustomEmojiId { get; set; }

    public int LightThemeMainColor { get; set; }

    public int[] LightThemeOtherColors { get; set; }

    public int DarkThemeMainColor { get; set; }

    public int[] DarkThemeOtherColors { get; set; }
}
