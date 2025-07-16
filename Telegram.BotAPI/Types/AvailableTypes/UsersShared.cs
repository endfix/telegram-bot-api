namespace Telegram.BotAPI.Types;

public sealed class UsersShared
{
    public int RequestId { get; set; }

    public SharedUser[] Users { get; set; }
}
