using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendMessageDraftParameters : ApiRequestParameters
{
    public required long ChatId { get; set; }

    public int? MessageThreadId { get; set; }

    public required int DraftId { get; set; }

    public required string Text { get; set; }

    public string? ParseMode { get; set; }

    public MessageEntity[]? Entities { get; set; }
}
