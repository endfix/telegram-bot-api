namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes the background of a chat.</summary>
public sealed class ChatBackground
{
    /// <summary>Type of the chat background.</summary>
    public required BackgroundType Type { get; init; }
}
