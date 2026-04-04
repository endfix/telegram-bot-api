using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class EditForumTopicParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required int MessageThreadId { get; init; }

    public string? Name { get; init; }

    public string? IconCustomEmojiId { get; init; }
}
