namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a connection between a business account and a bot.</summary>
public sealed class BusinessConnection
{
    /// <summary>Unique identifier of the business connection.</summary>
    public required string Id { get; init; }

    /// <summary>User who connected the business account.</summary>
    public required User User { get; init; }

    /// <summary>Unique identifier of the private chat with the user who connected the account.</summary>
    public required long UserChatId { get; init; }

    /// <summary>Date when the connection was established, in Unix time.</summary>
    public required int Date { get; init; }

    /// <summary>Rights granted to the bot, if available.</summary>
    public BusinessBotRights? Rights { get; init; }

    /// <summary>Indicates whether the connection is enabled.</summary>
    public required bool IsEnabled { get; init; }
}
