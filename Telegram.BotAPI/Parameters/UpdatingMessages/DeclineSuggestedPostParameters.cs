using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class DeclineSuggestedPostParameters : ApiRequestParameters
{
    public long ChatId { get; set; }

    public int MessageId { get; set; }

    public string Comment { get; set; }
}
