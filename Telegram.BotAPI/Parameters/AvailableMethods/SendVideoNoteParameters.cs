using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendVideoNoteParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public object VideoNote { get; set; }

    public int Duration { get; set; }

    public int Length { get; set; }

    public object Thumbnail { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public bool AllowPaidBroadcast { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}
