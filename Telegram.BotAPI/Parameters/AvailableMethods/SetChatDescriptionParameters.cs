using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setChatDescription</c> method.
/// </summary>
public sealed class SetChatDescriptionParameters : ApiRequestParameters
{
    /// <summary>Target chat identifier or channel username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>New chat description, from 0 through 255 characters.</summary>
    public string? Description { get; init; }
}
