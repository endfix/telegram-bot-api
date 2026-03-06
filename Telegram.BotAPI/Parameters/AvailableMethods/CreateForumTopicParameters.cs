namespace Telegram.BotAPI.Parameters;

public sealed class CreateForumTopicParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required string Name { get; init; }

    public int? IconColor { get; init; }

    public string? IconCustomEmojiId { get; init; }
}
