namespace Telegram.BotAPI.Types;

public sealed class Story
{
    public required Chat Chat { get; init; }

    public required long Id { get; init; }
}
