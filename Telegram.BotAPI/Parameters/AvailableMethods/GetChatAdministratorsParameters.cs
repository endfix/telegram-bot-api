using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getChatAdministrators</c> method.
/// </summary>
public sealed class GetChatAdministratorsParameters : ApiRequestParameters
{
    /// <summary>Target chat identifier or username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Whether to include all administrator bots. Other bots are omitted by default.</summary>
    public bool? ReturnBots { get; init; }
}
