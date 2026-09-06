namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes data sent from a Web App to the bot.
/// </summary>
public sealed class WebAppData
{
    /// <summary>Service message data sent by the Web App.</summary>
    public required string Data { get; init; }

    /// <summary>Text of the keyboard button used to launch the Web App.</summary>
    public required string ButtonText { get; init; }
}
