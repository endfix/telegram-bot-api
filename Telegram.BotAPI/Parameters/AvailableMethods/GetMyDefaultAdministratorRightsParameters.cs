using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getMyDefaultAdministratorRights</c> method.
/// </summary>
public sealed class GetMyDefaultAdministratorRightsParameters : ApiRequestParameters
{
    /// <summary>Whether to return channel rights instead of group and supergroup rights.</summary>
    public bool? ForChannels { get; init; }
}
