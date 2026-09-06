using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;
namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>savePreparedInlineMessage</c> method.
/// </summary>
public sealed class SavePreparedInlineMessageParameters : ApiRequestParameters
{
    /// <summary>Identifier of the user who can use the prepared message.</summary>
    public required long UserId { get; init; }

    /// <summary>Description of the message to save.</summary>
    public required InlineQueryResult Result { get; init; }

    /// <summary>Whether the message may be sent to private chats with users.</summary>
    public bool? AllowUserChats { get; init; }

    /// <summary>Whether the message may be sent to private chats with bots.</summary>
    public bool? AllowBotChats { get; init; }

    /// <summary>Whether the message may be sent to groups and supergroups.</summary>
    public bool? AllowGroupChats { get; init; }

    /// <summary>Whether the message may be sent to channels.</summary>
    public bool? AllowChannelChats { get; init; }
}
