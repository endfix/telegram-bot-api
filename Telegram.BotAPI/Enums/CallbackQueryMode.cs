namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>
/// Mode in which the bot receives callback queries from buttons in messages it
/// sent.
/// </summary>
public enum CallbackQueryMode
{
    /// <summary>
    /// The <c>message</c> field is always used and contains an
    /// <c>InaccessibleMessage</c> when the message is inaccessible to the bot.
    /// </summary>
    Default,

    /// <summary>
    /// <c>inline_message_id</c> is used instead of <c>message</c> when the message
    /// is inaccessible; <c>message</c> can still contain an inaccessible message
    /// if the message has just been deleted.
    /// </summary>
    Auto,

    /// <summary>
    /// <c>inline_message_id</c> is always used instead of <c>message</c>.
    /// </summary>
    Inline
}
