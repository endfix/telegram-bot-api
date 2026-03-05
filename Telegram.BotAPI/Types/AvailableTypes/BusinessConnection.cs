namespace Telegram.BotAPI.Types;

public sealed class BusinessConnection
{
    public required string Id { get; init; }

    public required User User { get; init; }

    public required int UserChatId { get; init; }

    public required int Date { get; init; }

    public BusinessBotRights? Rights { get; init; }

    public required bool IsEnabled { get; init; }
}
