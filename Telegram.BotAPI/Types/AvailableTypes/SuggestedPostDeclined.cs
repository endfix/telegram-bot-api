namespace Telegram.BotAPI.Types;

public sealed class SuggestedPostDeclined
{
    public Message SuggestedPostMessage { get; set; }

    public string Comment { get; set; }
}
