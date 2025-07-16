namespace Telegram.BotAPI.Parameters;

public sealed class SetUserEmojiStatusParameters : ApiRequestParameters
{
    public long UserId { get; set; }

    public string EmojiStatusCustomEmojiId { get; set; }

    public int EmojiStatusExpirationDate { get; set; }
}
