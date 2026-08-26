using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SendRichMessageDraftParameters : ApiRequestParameters
{
    public required long ChatId { get; init; }

    public long? MessageThreadId { get; init; }

    public required long DraftId { get; init; }

    public required InputRichMessage RichMessage { get; init; }

    public bool? CanStop { get; init; }

    public bool? KeepOnStop { get; init; }
}
