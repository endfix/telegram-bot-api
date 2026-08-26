using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendRichMessageDraftParameters : ApiRequestParameters
{
    public required long ChatId { get; init; }

    public long? MessageThreadId { get; init; }

    public required long DraftId { get; init; }

    public required InputRichMessage RichMessage { get; init; }

    public bool? CanStop { get; init; }

    public bool? KeepOnStop { get; init; }
}
