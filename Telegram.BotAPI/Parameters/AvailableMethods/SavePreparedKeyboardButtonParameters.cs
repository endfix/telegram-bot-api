using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>savePreparedKeyboardButton</c> method.
/// </summary>
public sealed class SavePreparedKeyboardButtonParameters : ApiRequestParameters
{
    /// <summary>Identifier of the user who can use the prepared button.</summary>
    public required long UserId { get; init; }

    /// <summary>Button to save. It must be a <c>request_users</c>, <c>request_chat</c>, or <c>request_managed_bot</c> button.</summary>
    public required KeyboardButton Button { get; init; }
}
