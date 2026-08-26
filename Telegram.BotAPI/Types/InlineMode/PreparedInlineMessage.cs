namespace Endfix.Telegram.BotAPI.Types;

public sealed class PreparedInlineMessage
{
    public required string Id { get; init; }

    public required int ExpirationDate { get; init; }
}
