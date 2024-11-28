using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Requests.AvailableMethods;

public sealed class SendVideoNoteParameters : RequestParameters
{
    /// <summary>
    /// Optional. Unique identifier of the business connection on behalf of which the message will be sent
    /// </summary>
    public string BusinessConnectionId { get; set; }

    /// <summary>
    /// Unique identifier for the target chat or username of the target channel(in the format @channelusername)
    /// </summary>
    public string ChatId { get; set; }

    /// <summary>
    /// Optional. Unique identifier for the target message thread(topic) of the forum; for forum supergroups only
    /// </summary>
    public int MessageThreadId { get; set; }

    /// <summary>
    /// Video note to send.Pass a file_id as String to send a video note that exists on the Telegram servers (recommended) 
    /// or upload a new video using multipart/form-data.More information on Sending Files ». Sending video notes by a URL is currently unsupported
    /// </summary>
    public object VideoNote { get; set; }

    /// <summary>
    /// Optional. Duration of sent video in seconds
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    /// Optional. Video width and height, i.e.diameter of the video message
    /// </summary>
    public int Length { get; set; }

    /// <summary>
    /// Optional    Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side.
    /// The thumbnail should be in JPEG format and less than 200 kB in size.A thumbnail's width and height should not exceed 320.
    /// </summary>
    public object Thumbnail { get; set; }

    /// <summary>
    /// Optional. Sends the message silently.Users will receive a notification with no sound.
    /// </summary>
    public bool DisableNotification { get; set; }

    /// <summary>
    /// Optional. Protects the contents of the sent message from forwarding and saving
    /// </summary>
    public bool ProtectContent { get; set; }

    /// <summary>
    /// Optional. Pass True to allow up to 1000 messages per second, ignoring broadcasting limits for a fee of 0.1 Telegram Stars per message. 
    /// The relevant Stars will be withdrawn from the bot's balance
    /// </summary>
    public bool AllowPaidBroadcast { get; set; }

    /// <summary>
    /// Optional. Unique identifier of the message effect to be added to the message; for private chats only
    /// </summary>
    public string MessageEffectId { get; set; }

    /// <summary>
    /// Optional. Description of the message to reply to
    /// </summary>
    public ReplyParameters ReplyParameters { get; set; }

    /// <summary>
    /// Additional interface options. A JSON-serialized object for an <see href="https://core.telegram.org/bots/features#inline-keyboards">inline keyboard</see>, 
    /// <see href="https://core.telegram.org/bots/features#keyboards">custom reply keyboard</see>, instructions to remove a reply keyboard or to force a reply from the user
    /// </summary>
    public ReplyMarkup ReplyMarkup { get; set; }
}
