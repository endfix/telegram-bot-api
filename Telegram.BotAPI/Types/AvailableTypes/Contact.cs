namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a shared phone contact.</summary>
public sealed class Contact
{
    /// <summary>Contact's phone number.</summary>
    public required string PhoneNumber { get; init; }

    /// <summary>Contact's first name.</summary>
    public required string FirstName { get; init; }

    /// <summary>Contact's last name, if available.</summary>
    public string? LastName { get; init; }

    /// <summary>Contact's Telegram user identifier, if available.</summary>
    public long? UserId { get; init; }

    /// <summary>Additional contact data in vCard format, if available.</summary>
    public string? VCard { get; init; }
}
