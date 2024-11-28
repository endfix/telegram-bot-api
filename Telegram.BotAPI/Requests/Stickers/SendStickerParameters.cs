using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Requests.Stickers;

public sealed class SendStickerParameters : RequestParameters
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public object Sticker { get; set; }

    public string Emoji { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public bool AllowPaidBroadcast { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}
