namespace Endfix.Telegram.BotAPI.Types;

public sealed class KeyboardButtonRequestManagedBot
{
    public required int RequestId { get; init; }

    public string? SuggestedName { get; init; }

    public string? SuggestedUsername { get; init; }
}
