namespace Endfix.Telegram.BotAPI.Types;

public sealed class InputRichMessageMedia
{
    public required string Id { get; init; }

    public required InputMedia Media { get; init; }
}
