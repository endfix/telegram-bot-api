using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class EditMessageLiveLocationParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public long MessageId { get; set; }

    public string InlineMessageId { get; set; }

    public float Latitude { get; set; }

    public float Longitude { get; set; }

    public int LivePeriod { get; set; }

    public float HorizontalAccuracy { get; set; }

    public int Heading { get; set; }

    public int ProximityAlertRadius { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}
