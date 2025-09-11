using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendLocationParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public int DirectMessagesTopicId { get; set; }

    public float Latitude { get; set; }

    public float Longitude { get; set; }

    public float HorizontalAccuracy { get; set; }

    public int LivePeriod { get; set; }

    public int Heading { get; set; }

    public int ProximityAlertRadius { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public bool AllowPaidBroadcast { get; set; }

    public string MessageEffectId { get; set; }

    public SuggestedPostParameters SuggestedPostParameters { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}
