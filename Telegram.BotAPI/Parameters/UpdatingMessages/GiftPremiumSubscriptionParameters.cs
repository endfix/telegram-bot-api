using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class GiftPremiumSubscriptionParameters : ApiRequestParameters
{
    public long UserId { get; set; }

    public int MonthCount { get; set; }

    public int StarCount { get; set; }

    public string Text { get; set; }

    public string TextParseMode { get; set; }

    public MessageEntity[] TextEntities { get; set; }
}
