using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendGiftParameters : ApiRequestParameters
{
    public long UserId { get; set; }

    public object ChatId { get; set; }

    public string GiftId { get; set; }

    public bool PayForUpgrade { get; set; }

    public string Text { get; set; }

    public string TextParseMode { get; set; }

    public MessageEntity[] TextEntities { get; set; }
}
