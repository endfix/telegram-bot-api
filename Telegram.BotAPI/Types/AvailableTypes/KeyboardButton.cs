namespace Telegram.BotAPI.Types;

public sealed class KeyboardButton
{
    public string Text { get; set; }

    public bool RequestContact { get; set; }

    public bool RequestLocation { get; set; }

    public KeyboardButtonPollType RequestPoll { get; set; }

    public WebAppInfo WebApp { get; set; }
}
