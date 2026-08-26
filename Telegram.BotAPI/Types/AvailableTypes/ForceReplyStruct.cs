namespace Endfix.Telegram.BotAPI.Types;

public sealed class ForceReplyStruct : ReplyMarkup
{
    public required bool ForceReply { get; init; }

    public string? InputFieldPlaceholder { get; init; }

    public bool? Selective { get; init; }
}
