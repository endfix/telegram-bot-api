using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Requests.Games;

public sealed class SendGameParameters : RequestParameters
{
    /// <summary>
    /// Unique identifier of the business connection on behalf of which the message will be sent
    /// </summary>
    public string BusinessConnectionId { get; set; }

    /// <summary>
    /// Unique identifier for the target chat
    /// </summary>
    public long ChatId { get; set; }

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int MessageThreadId { get; set; }

    /// <summary>
    /// Short name of the game, serves as the unique identifier for the game. Set up your games via <see href="https://t.me/botfather">@BotFather</see>.
    /// </summary>
    public string GameShortName { get; set; }

    /// <summary>
    /// Sends the message <see href="https://telegram.org/blog/channels-2-0#silent-messages">silently</see>. Users will receive a notification with no sound.
    /// </summary>
    public bool DisableNotification { get; set; }

    /// <summary>
    /// Protects the contents of the sent message from forwarding and saving
    /// </summary>
    public bool ProtectContent { get; set; }

    /// <summary>
    /// Pass True to allow up to 1000 messages per second, 
    /// ignoring <see href="https://core.telegram.org/bots/faq#how-can-i-message-all-of-my-bot-39s-subscribers-at-once">broadcasting limits</see> 
    /// for a fee of 0.1 Telegram Stars per message. The relevant Stars will be withdrawn from the bot's balance
    /// </summary>
    public bool AllowPaidBroadcast { get; set; }

    /// <summary>
    /// Unique identifier of the message effect to be added to the message; for private chats only
    /// </summary>
    public string MessageEffectId { get; set; }

    /// <summary>
    /// Description of the message to reply to
    /// </summary>
    public ReplyParameters ReplyParameters { get; set; }

    /// <summary>
    /// A JSON-serialized object for an <see href="https://core.telegram.org/bots/features#inline-keyboards">inline keyboard</see>. 
    /// If empty, one 'Play game_title' button will be shown. If not empty, the first button must launch the game.
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}
