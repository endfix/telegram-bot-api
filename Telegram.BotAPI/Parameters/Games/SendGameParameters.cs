using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendGameParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public long ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public string GameShortName { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public bool AllowPaidBroadcast { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}
