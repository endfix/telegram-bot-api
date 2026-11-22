using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setMySettings</c> method.
/// </summary>
public sealed class SetMySettingsParameters : ApiRequestParameters
{
    /// <summary>Whether inline mode is enabled for the bot.</summary>
    public bool? SupportsInlineQueries { get; init; }

    /// <summary>Placeholder shown after the bot's username in inline mode. An empty string restores the default placeholder.</summary>
    public string? InlineQueryPlaceholder { get; init; }

    /// <summary>Whether the bot requests the user's location with every inline query.</summary>
    public bool? NeedsInlineQueryLocation { get; init; }

    /// <summary>
    /// Denominator of the share of chosen inline results delivered to the bot: it
    /// receives 1 of every <c>inline_feedback_share_denominator</c> results. Must
    /// be 1, 10, 100, or 1000; 0 stops the delivery.
    /// </summary>
    public int? InlineFeedbackShareDenominator { get; init; }

    /// <summary>Whether the bot can be added to groups.</summary>
    public bool? CanJoinGroups { get; init; }

    /// <summary>Whether privacy mode is disabled for the bot, so it receives all group messages.</summary>
    public bool? CanReadAllGroupMessages { get; init; }

    /// <summary>Whether the bot can be connected to a user account to manage it.</summary>
    public bool? CanConnectToBusiness { get; init; }

    /// <summary>Whether the bot can create other bots that it controls.</summary>
    public bool? CanManageBots { get; init; }

    /// <summary>Whether the bot supports guest queries from chats it is not a member of.</summary>
    public bool? SupportsGuestQueries { get; init; }

    /// <summary>Whether the bot can be assigned to process join request queries.</summary>
    public bool? SupportsJoinRequestQueries { get; init; }

    /// <summary>Whether forum topic mode is enabled in private chats with the bot.</summary>
    public bool? HasTopicsEnabled { get; init; }

    /// <summary>Whether users can create and delete topics in private chats with the bot.</summary>
    public bool? AllowsUsersToCreateTopics { get; init; }

    /// <summary>Whether topics in private chats with the bot are shown in a sidebar.</summary>
    public bool? HasTopicSidebar { get; init; }

    /// <summary>Whether the bot can communicate with other bots in groups, private chats, and through business accounts.</summary>
    public bool? CanCommunicateWithBots { get; init; }

    /// <summary>Mode for callback queries from buttons in messages sent by the bot.</summary>
    public CallbackQueryMode? CallbackQueryMode { get; init; }
}
