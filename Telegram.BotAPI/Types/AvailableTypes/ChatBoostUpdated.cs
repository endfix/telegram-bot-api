namespace Endfix.Telegram.BotAPI.Types;

public sealed class ChatBoostUpdated
{
    public required Chat Chat { get; init; }

    public required ChatBoost Boost { get; init; }
}
