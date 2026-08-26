using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class ReplyKeyboardMarkup : ReplyMarkup
{
    public required IReadOnlyList<IReadOnlyList<KeyboardButton>> Keyboard { get; init; }

    public bool? IsPersistent { get; init; }

    public bool? ResizeKeyboard { get; init; }

    public bool? OneTimeKeyboard { get; init; }

    public string? InputFieldPlaceholder { get; init; }

    public bool? Selective { get; init; }

    public bool? ForceReply { get; init; }
}
