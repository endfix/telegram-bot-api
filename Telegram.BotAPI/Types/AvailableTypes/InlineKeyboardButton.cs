using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents one button in an inline keyboard.</summary>
public sealed class InlineKeyboardButton
{
    /// <summary>Label of the button.</summary>
    public required string Text { get; init; }

    /// <summary>Custom emoji shown as the button icon, if available.</summary>
    public string? IconCustomEmojiId { get; init; }

    /// <summary>Visual style of the button, if configured.</summary>
    public KeyboardButtonStyle? Style { get; init; }

    /// <summary>HTTP or Telegram URL opened by the button, if configured.</summary>
    public string? Url { get; init; }

    /// <summary>Data sent in the callback query, if configured.</summary>
    public string? CallbackData { get; init; }

    /// <summary>Web App launched by the button, if configured.</summary>
    public WebAppInfo? WebApp { get; init; }

    /// <summary>Login URL opened by the button, if configured.</summary>
    public LoginUrl? LoginUrl { get; init; }

    /// <summary>Inline query inserted after switching to inline mode, if configured.</summary>
    public string? SwitchInlineQuery { get; init; }

    /// <summary>Inline query inserted in the current chat, if configured.</summary>
    public string? SwitchInlineQueryCurrentChat { get; init; }

    /// <summary>Configuration for choosing a chat in which to switch to inline mode, if configured.</summary>
    public SwitchInlineQueryChosenChat? SwitchInlineQueryChosenChat { get; init; }

    /// <summary>Copy-text action performed by the button, if configured.</summary>
    public CopyTextButton? CopyText { get; init; }

    /// <summary>Callback game launched by the button, if configured.</summary>
    public CallbackGame? CallbackGame { get; init; }

    /// <summary>Indicates whether the button is a payment button.</summary>
    public bool? Pay { get; init; }
}
