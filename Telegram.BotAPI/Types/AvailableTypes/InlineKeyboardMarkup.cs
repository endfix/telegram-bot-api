using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an inline keyboard attached to a message.</summary>
public sealed class InlineKeyboardMarkup : ReplyMarkup
{
    /// <summary>Rows of inline keyboard buttons.</summary>
    public required IReadOnlyList<IReadOnlyList<InlineKeyboardButton>> InlineKeyboard { get; init; }

    /// <summary>Indicates whether the keyboard should force a reply in supported contexts.</summary>
    public bool? ForceReply { get; init; }
}
