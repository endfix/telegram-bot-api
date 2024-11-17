using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Types.InlineMode;

/// <summary>
/// This object represents a button to be shown above inline query results. You must use exactly one of the optional fields.
/// </summary>
public sealed class InlineQueryResultsButton
{
    /// <summary>
    /// Label text on the button
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Optional. Description of the <see href="https://core.telegram.org/bots/webapps">Web App</see> that will be launched when the user presses the button. 
    /// The Web App will be able to switch back to the inline mode using the method <see href="https://core.telegram.org/bots/webapps#initializing-mini-apps">switchInlineQuery</see> inside the Web App.
    /// </summary>
    public WebAppInfo WebApp { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#deep-linking">Deep-linking</see> parameter for the /start message sent to the bot when a user presses the button. 1-64 characters, only A-Z, a-z, 0-9, _ and - are allowed.
    /// 
    /// Example: An inline bot that sends YouTube videos can ask the user to connect the bot to their YouTube account to adapt search results accordingly.To do this, 
    /// it displays a 'Connect your YouTube account' button above the results, or even before showing any.The user presses the button, 
    /// switches to a private chat with the bot and, in doing so, passes a start parameter that instructs the bot to return an OAuth link.Once done, 
    /// the bot can offer a <see href="https://core.telegram.org/bots/api#inlinekeyboardmarkup">switch_inline</see> button so that the user can easily return to the chat where they wanted to use the bot's inline capabilities.
    /// </summary>
    public string StartParameter { get; set; }
}
