using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class StopPollParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public long MessageId { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}
