namespace Endfix.Telegram.BotAPI.Types;

public sealed class ForumTopic
{
    public required long MessageThreadId { get; init; }

    public required string Name { get; init; }

    public required int IconColor { get; init; }

    public string? IconCustomEmojiId { get; init; }

    public bool? IsNameImplicit { get; init; }
}
