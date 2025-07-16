namespace Telegram.BotAPI.Types;

public abstract class MaybeInaccessibleMessage
{
    //
}

public sealed class InaccessibleMessage : MaybeInaccessibleMessage
{
    public Chat Chat { get; set; }

    public int MessageId { get; set; }

    public int Date { get; set; }
}
