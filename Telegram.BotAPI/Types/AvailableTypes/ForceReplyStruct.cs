namespace Telegram.BotAPI.Types;

public sealed class ForceReplyStruct : ReplyMarkup
{
    public bool ForceReply { get; set; }

    public string InputFieldPlaceholder { get; set; }

    public bool Selective { get; set; }
}
