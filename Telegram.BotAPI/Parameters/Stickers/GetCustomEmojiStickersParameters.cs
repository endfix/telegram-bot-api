namespace Telegram.BotAPI.Parameters;

public sealed class GetCustomEmojiStickersParameters : ApiRequestParameters
{
    public string[] CustomEmojiIds { get; set; }
}
