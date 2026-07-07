namespace Telegram.BotAPI.Types;

public sealed class RichBlockCaption
{
    public required RichText Text { get; init; }

    public RichText? Credit { get; init; }
}
