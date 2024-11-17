namespace Telegram.BotAPI.Types.InlineMode;

/// <summary>
/// Describes an inline message sent by a <see href="https://core.telegram.org/bots/webapps">Web App</see> on behalf of a user.
/// </summary>
public sealed class SentWebAppMessage
{
    /// <summary>
    /// Optional. Identifier of the sent inline message. Available only if there 
    /// is an <see href="https://core.telegram.org/bots/api#inlinekeyboardmarkup">inline keyboard</see> attached to the message.
    /// </summary>
    public string InlineMessageId { get; set; }
}
