using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendAudioParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public object Audio { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public int Duration { get; set; }

    public string Performer { get; set; }

    public string Title { get; set; }

    public object Thumbnail { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}
