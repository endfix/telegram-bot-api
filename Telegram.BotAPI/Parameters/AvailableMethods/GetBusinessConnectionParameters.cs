using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getBusinessConnection</c> method.
/// </summary>
public sealed class GetBusinessConnectionParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }
}
