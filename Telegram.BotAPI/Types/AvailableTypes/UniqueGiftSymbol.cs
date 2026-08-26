namespace Endfix.Telegram.BotAPI.Types;

public sealed class UniqueGiftSymbol
{
    public required string Name { get; init; }

    public required Sticker Sticker { get; init; }

    public required int RarityPerMille { get; init; }
}
