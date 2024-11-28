namespace Telegram.BotAPI.Requests.Games;

public sealed class GetGameHighScoresParameters : RequestParameters
{
    /// <summary>
    /// Target user id
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Required if inline_message_id is not specified. Unique identifier for the target chat
    /// </summary>
    public long ChatId { get; set; }

    /// <summary>
    /// Required if inline_message_id is not specified. Identifier of the sent message
    /// </summary>
    public long MessageId { get; set; }

    /// <summary>
    /// Required if chat_id and message_id are not specified. Identifier of the inline message
    /// </summary>
    public string InlineMessageId { get; set; }
}
