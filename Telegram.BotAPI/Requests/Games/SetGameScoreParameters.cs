namespace Telegram.BotAPI.Requests.Games;

public sealed class SetGameScoreParameters : RequestParameters
{
    /// <summary>
    /// User identifier
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// New score, must be non-negative
    /// </summary>
    public int Score { get; set; }

    /// <summary>
    /// Pass True if the high score is allowed to decrease. This can be useful when fixing mistakes or banning cheaters
    /// </summary>
    public bool Force { get; set; }

    /// <summary>
    /// Pass True if the game message should not be automatically edited to include the current scoreboard
    /// </summary>
    public bool DisableEditMessage { get; set; }

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
