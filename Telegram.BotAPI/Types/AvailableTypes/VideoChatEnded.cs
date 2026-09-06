namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a service message about a video chat ended in the chat.
/// </summary>
public sealed class VideoChatEnded
{
    /// <summary>Video chat duration in seconds.</summary>
    public required int Duration { get; init; }
}
