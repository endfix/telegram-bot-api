namespace Endfix.Telegram.BotAPI.Types;

public sealed class UniqueGiftBackdrop
{
    public required string Name { get; init; }

    public required UniqueGiftBackdropColors Colors { get; init; }

    public required int RarityPerMille { get; init; }
}
