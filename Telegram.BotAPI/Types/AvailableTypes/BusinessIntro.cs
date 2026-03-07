namespace Telegram.BotAPI.Types;

public sealed class BusinessIntro
{
    public string? Name { get; init; }

    public string? Message { get; init; }

    public Sticker? Sticker { get; init; }
}
