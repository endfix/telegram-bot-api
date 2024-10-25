namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#contact
public sealed class Contact
{
    public string PhoneNumber { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public long UserId { get; set; }

    public string VCard { get; set; }
}
