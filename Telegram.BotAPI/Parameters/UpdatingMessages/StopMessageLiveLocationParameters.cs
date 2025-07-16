using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class StopMessageLiveLocationParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public long MessageId { get; set; }

    public string InlineMessageId { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}
