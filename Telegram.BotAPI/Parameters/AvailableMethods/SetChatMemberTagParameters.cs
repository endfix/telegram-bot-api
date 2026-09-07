using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setChatMemberTag</c> method.
/// </summary>
public sealed class SetChatMemberTagParameters : ApiRequestParameters
{
    /// <summary>Target group or supergroup identifier or username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target member identifier.</summary>
    public required long UserId { get; init; }

    /// <summary>New member tag, from 0 through 16 characters; emoji are not allowed.</summary>
    public string? Tag { get; init; }
}
