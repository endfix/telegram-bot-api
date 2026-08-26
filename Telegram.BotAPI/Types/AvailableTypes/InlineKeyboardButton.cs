using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class InlineKeyboardButton
{
    public required string Text { get; init; }

    public string? IconCustomEmojiId { get; init; }

    public KeyboardButtonStyle? Style { get; init; }

    public string? Url { get; init; }

    public string? CallbackData { get; init; }

    public WebAppInfo? WebApp { get; init; }

    public LoginUrl? LoginUrl { get; init; }

    public string? SwitchInlineQuery { get; init; }

    public string? SwitchInlineQueryCurrentChat { get; init; }

    public SwitchInlineQueryChosenChat? SwitchInlineQueryChosenChat { get; init; }

    public CopyTextButton? CopyText { get; init; }

    public CallbackGame? CallbackGame { get; init; }

    public bool? Pay { get; init; }
}
