namespace Endfix.Telegram.BotAPI.Types;

public sealed class RichBlockCaption
{
    public required RichTextSource Text { get; init; }

    public RichTextSource? Credit { get; init; }
}
