using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>verifyChat</c> method.
/// </summary>
public sealed class VerifyChatParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public string? CustomDescription { get; init; }
}
