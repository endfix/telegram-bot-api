namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a request to create or select a managed bot.</summary>
public sealed class KeyboardButtonRequestManagedBot
{
    /// <summary>Identifier of the request.</summary>
    public required int RequestId { get; init; }

    /// <summary>Suggested name for the managed bot, if provided.</summary>
    public string? SuggestedName { get; init; }

    /// <summary>Suggested username for the managed bot, if provided.</summary>
    public string? SuggestedUsername { get; init; }
}
