namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Forces clients to show a reply interface to the user.</summary>
public sealed class ForceReplyStruct : ReplyMarkup
{
    /// <summary>Must be set to <see langword="true"/> to show the reply interface.</summary>
    public required bool ForceReply { get; init; }

    /// <summary>Placeholder shown in the input field while the reply interface is active.</summary>
    public string? InputFieldPlaceholder { get; init; }

    /// <summary>Indicates whether the reply interface should be shown only to specific users.</summary>
    public bool? Selective { get; init; }
}
