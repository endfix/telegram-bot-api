namespace Telegram.BotAPI.Types;

public sealed class ForumTopicCreated
{
    public required string Name { get; init; }

    public required int IconColor { get; init; }

    public string? IconCustomEmojiId { get; init; }

    public bool? IsNameImplicit { get; init; }
}
