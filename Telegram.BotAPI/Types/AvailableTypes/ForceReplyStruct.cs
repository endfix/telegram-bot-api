namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class ForceReplyStruct : ReplyMarkup
{
    public bool ForceReply { get; set; }

    public string InputFieldPlaceholder { get; set; }

    public bool Selective { get; set; }
}
