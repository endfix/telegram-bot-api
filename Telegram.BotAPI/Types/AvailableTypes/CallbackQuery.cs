namespace Telegram.BotAPI.Types;

public sealed class CallbackQuery
{
    public string Id { get; set; }

    public User From { get; set; }

    public MaybeInaccessibleMessage Message { get; set; }

    public string InlineMessageId { get; set; }

    public string ChatInstance { get; set; }

    public string Data { get; set; }

    public string GameShortName { get; set; }
}
