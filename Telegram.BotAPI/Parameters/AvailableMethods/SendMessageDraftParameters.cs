using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendMessageDraftParameters : ApiRequestParameters
{
    public long ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public int DraftId { get; set; }

    public string Text { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] Entities { get; set; }
}
