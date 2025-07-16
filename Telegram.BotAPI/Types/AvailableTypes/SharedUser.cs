namespace Telegram.BotAPI.Types;

public sealed class SharedUser
{
    public long UserId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Username { get; set; }

    public PhotoSize[] Photo { get; set; }
}
