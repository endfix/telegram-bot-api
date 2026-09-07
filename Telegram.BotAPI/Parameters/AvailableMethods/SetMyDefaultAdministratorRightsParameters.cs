using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setMyDefaultAdministratorRights</c> method.
/// </summary>
public sealed class SetMyDefaultAdministratorRightsParameters : ApiRequestParameters
{
    /// <summary>New default rights. Omit them to clear the configured defaults.</summary>
    public ChatAdministratorRights? Rights { get; init; }

    /// <summary>Whether to change channel rights instead of group and supergroup rights.</summary>
    public bool? ForChannels { get; init; }
}
