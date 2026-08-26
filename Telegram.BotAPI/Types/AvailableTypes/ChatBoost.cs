namespace Endfix.Telegram.BotAPI.Types;

public sealed class ChatBoost
{
    public required string BoostId { get; init; }

    public required int AddDate { get; init; }

    public required int ExpirationDate { get; init; }

    public required ChatBoostSource Source { get; init; }
}
