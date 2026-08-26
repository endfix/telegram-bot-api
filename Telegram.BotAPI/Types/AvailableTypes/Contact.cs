namespace Endfix.Telegram.BotAPI.Types;

public sealed class Contact
{
    public required string PhoneNumber { get; init; }

    public required string FirstName { get; init; }

    public string? LastName { get; init; }

    public long? UserId { get; init; }

    public string? VCard { get; init; }
}
