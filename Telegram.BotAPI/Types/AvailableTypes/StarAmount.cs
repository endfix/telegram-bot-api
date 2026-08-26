namespace Endfix.Telegram.BotAPI.Types;

public sealed class StarAmount
{
    public required int Amount {  get; init; }

    public int? NanostarAmount { get; init; }
}
