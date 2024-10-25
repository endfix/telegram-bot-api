namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#forcereply
public sealed class ForceReplyStruct : ReplyMarkup
{
    public bool ForceReply { get; set; }

    public string InputFieldPlaceholder { get; set; }

    public bool Selective { get; set; }
}
