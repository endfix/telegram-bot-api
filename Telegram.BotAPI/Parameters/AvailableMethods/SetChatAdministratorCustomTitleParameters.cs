using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setChatAdministratorCustomTitle</c> method.
/// </summary>
public sealed class SetChatAdministratorCustomTitleParameters : ApiRequestParameters
{
    /// <summary>Target supergroup identifier or username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target administrator identifier.</summary>
    public required long UserId { get; init; }

    /// <summary>New administrator title, from 0 through 16 characters; emoji are not allowed.</summary>
    public required string CustomTitle { get; init; }
}
