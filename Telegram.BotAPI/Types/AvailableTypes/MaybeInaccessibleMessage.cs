namespace Endfix.Telegram.BotAPI.Types;

public abstract class MaybeInaccessibleMessage
{
    public required virtual Chat Chat { get; init; }

    public required virtual long MessageId { get; init; }

    public required virtual long Date { get; init; }
}
