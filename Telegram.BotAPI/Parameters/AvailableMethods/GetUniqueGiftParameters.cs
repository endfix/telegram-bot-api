using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>Parameters for the <c>getUniqueGift</c> method.</summary>
public sealed class GetUniqueGiftParameters : ApiRequestParameters
{
    /// <summary>Unique name of the gift.</summary>
    public required string Name { get; init; }
}
