using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class InlineKeyboardButton
{
    public required string Text { get; set; }

    public string? IconCustomEmojiId { get; set; }

    public KeyboardButtonStyles Style { get; set; }

    public string? Url { get; set; }

    public string? CallbackData { get; set; }

    public WebAppInfo? WebApp { get; set; }

    public LoginUrl? LoginUrl { get; set; }

    public string? SwitchInlineQuery { get; set; }

    public string? SwitchInlineQueryCurrentChat { get; set; }

    public SwitchInlineQueryChosenChat? SwitchInlineQueryChosenChat { get; set; }

    public CopyTextButton? CopyText { get; set; }

    public CallbackGame? CallbackGame { get; set; }

    public bool Pay { get; set; }
}
