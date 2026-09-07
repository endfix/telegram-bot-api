using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>createChatSubscriptionInviteLink</c> method.
/// </summary>
public sealed class CreateChatSubscriptionInviteLinkParameters : ApiRequestParameters
{
    /// <summary>Gets the unique identifier or username of the target channel.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Gets the invite link name, containing 0-32 characters.</summary>
    public string? Name { get; init; }

    /// <summary>Gets the subscription duration in seconds before the next payment. Currently, this value must be 2592000 (30 days).</summary>
    public required int SubscriptionPeriod { get; init; }

    /// <summary>Gets the number of Telegram Stars charged initially and after each subscription period; 1-10000.</summary>
    public required int SubscriptionPrice { get; init; }
}
