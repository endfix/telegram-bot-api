using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a custom reply keyboard displayed to the user.</summary>
public sealed class ReplyKeyboardMarkup : ReplyMarkup
{
    /// <summary>Rows of keyboard buttons.</summary>
    public required IReadOnlyList<IReadOnlyList<KeyboardButton>> Keyboard { get; init; }

    /// <summary>Indicates whether the keyboard should remain visible when no longer needed.</summary>
    public bool? IsPersistent { get; init; }

    /// <summary>Requests that clients resize the keyboard vertically for an optimal fit.</summary>
    public bool? ResizeKeyboard { get; init; }

    /// <summary>Requests that clients hide the keyboard after a button is pressed.</summary>
    public bool? OneTimeKeyboard { get; init; }

    /// <summary>Placeholder shown in the input field while the keyboard is active.</summary>
    public string? InputFieldPlaceholder { get; init; }

    /// <summary>Indicates whether the keyboard should be shown only to specific users.</summary>
    public bool? Selective { get; init; }

    /// <summary>Indicates whether the client should force a reply.</summary>
    public bool? ForceReply { get; init; }
}
