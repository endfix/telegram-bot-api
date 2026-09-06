namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a button in a rich message.</summary>
public sealed class RichMessageButton
{
    /// <summary>Button label.</summary>
    public required RichText Text { get; init; }

    /// <summary>Optional. Button style.</summary>
    public string? Style { get; init; }

    /// <summary>Optional. HTTP or Telegram URL opened when the button is pressed.</summary>
    public string? Url { get; init; }

    /// <summary>Optional. Data sent to the bot when the button is pressed.</summary>
    public string? CallbackData { get; init; }

    /// <summary>Optional. Web App opened when the button is pressed.</summary>
    public WebAppInfo? WebApp { get; init; }

    /// <summary>Optional. Login URL opened when the button is pressed.</summary>
    public LoginUrl? LoginUrl { get; init; }

    /// <summary>Optional. Inline query inserted when the button is pressed.</summary>
    public string? SwitchInlineQuery { get; init; }

    /// <summary>Optional. Inline query inserted for the current chat when the button is pressed.</summary>
    public string? SwitchInlineQueryCurrentChat { get; init; }

    /// <summary>Optional. Configuration for choosing a chat before switching to inline mode.</summary>
    public SwitchInlineQueryChosenChat? SwitchInlineQueryChosenChat { get; init; }

    /// <summary>Optional. Copy-text action performed when the button is pressed.</summary>
    public CopyTextButton? CopyText { get; init; }

    /// <summary>Optional. Indicates that the button is disabled.</summary>
    public DisabledButton? Disabled { get; init; }
}
