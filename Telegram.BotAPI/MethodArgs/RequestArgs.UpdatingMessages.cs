using System.Collections.Generic;
using Telegram.BotAPI.Types.Input;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.MethodArgs;

public sealed class EditMessageTextArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public long MessageId { get; set; }

    public string InlineMessageId { get; set; }

    public string Text { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> Entities { get; set; }

    public LinkPreviewOptions LinkPreviewOptions { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}

public sealed class EditMessageCaptionArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public long MessageId { get; set; }

    public string InlineMessageId { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}

public sealed class EditMessageMediaArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public long MessageId { get; set; }

    public string InlineMessageId { get; set; }

    public InputMedia Media { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}

public sealed class EditMessageLiveLocationArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

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

public sealed class StopMessageLiveLocationArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public long MessageId { get; set; }

    public string InlineMessageId { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}

public sealed class EditMessageReplyMarkupArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public long MessageId { get; set; }

    public string InlineMessageId { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}

public sealed class StopPollArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public long MessageId { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}

public sealed class DeleteMessageArgs : RequestArgs
{
    public string ChatId { get; set; }

    public long MessageId { get; set; }
}

public sealed class DeleteMessagesArgs : RequestArgs
{
    public string ChatId { get; set; }

    public List<long> MessageIds { get; set; }
}
