namespace Telegram.BotAPI.Types;

public sealed class LoginUrl
{
    public required string Url { get; init; }

    public string? ForwardText { get; init; }

    public string? BotUsername { get; init; }

    public bool? RequestWriteAccess { get; init; }
}
