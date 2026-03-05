namespace Telegram.BotAPI.Types;

public abstract class MaybeInaccessibleMessage
{
    public required virtual Chat Chat { get; init; }

    public required virtual int MessageId { get; init; }

    public required virtual int Date { get; init; }
}
