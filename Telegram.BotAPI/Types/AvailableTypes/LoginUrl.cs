namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class LoginUrl
{
    public string Url { get; set; }

    public string ForwardText { get; set; }

    public string BotUsername { get; set; }

    public bool RequestWriteAccess { get; set; }
}
