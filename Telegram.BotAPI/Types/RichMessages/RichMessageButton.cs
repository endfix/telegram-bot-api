namespace Telegram.BotAPI.Types;

public sealed class RichMessageButton
{
    public required RichText Text { get; init; }

    public string? Style { get; init; }

    public string? Url { get; init; }

    public string? CallbackData { get; init; }

    public WebAppInfo? WebApp { get; init; }

    public LoginUrl? LoginUrl { get; init; }

    public string? SwitchInlineQuery { get; init; }

    public string? SwitchInlineQueryCurrentChat { get; init; }

    public SwitchInlineQueryChosenChat? SwitchInlineQueryChosenChat { get; init; }

    public CopyTextButton? CopyText { get; init; }

    public DisabledButton? Disabled { get; init; }
}
