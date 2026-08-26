using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class InlineKeyboardMarkup : ReplyMarkup
{
    public required IReadOnlyList<IReadOnlyList<InlineKeyboardButton>> InlineKeyboard { get; init; }

    public bool? ForceReply { get; init; }
}
