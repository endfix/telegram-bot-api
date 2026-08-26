namespace Endfix.Telegram.BotAPI.Types;

public sealed class ChatBoostRemoved
{
    public required Chat Chat { get; init; }

    public required string BoostId { get; init; }

    public required int RemoveDate { get; init; }

    public required ChatBoostSource Source { get; init; }
}
