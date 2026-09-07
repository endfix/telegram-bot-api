using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendPoll</c> method.
/// </summary>
public sealed class SendPollParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection on whose behalf the message is sent.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Target chat identifier or username. Channel direct messages chats are not supported.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target message thread identifier.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Poll question, from 1 through 300 characters.</summary>
    public required string Question { get; init; }

    /// <summary>Mode for parsing entities in the question; currently only custom emoji entities are allowed.</summary>
    public string? QuestionParseMode { get; init; }

    /// <summary>Special entities in the question; can be specified instead of <see cref="QuestionParseMode"/>.</summary>
    public IReadOnlyList<MessageEntity>? QuestionEntities { get; init; }

    /// <summary>Answer options; from 1 through 12 items.</summary>
    public required IReadOnlyList<InputPollOption> Options { get; init; }

    /// <summary>Whether the poll is anonymous. Defaults to <see langword="true"/>.</summary>
    public bool? IsAnonymous { get; init; }

    /// <summary>Poll type. Defaults to a regular poll.</summary>
    public PollType? Type { get; init; }

    /// <summary>Whether the poll allows multiple answers. Defaults to <see langword="false"/>.</summary>
    public bool? AllowsMultipleAnswers { get; init; }

    /// <summary>Whether voters may change their selected options. Defaults to <see langword="false"/> for quizzes and <see langword="true"/> for regular polls.</summary>
    public bool? AllowsRevoting { get; init; }

    /// <summary>Whether the answer options are shown in random order.</summary>
    public bool? ShuffleOptions { get; init; }

    /// <summary>Whether answer options can be added after creation; not supported for anonymous polls and quizzes.</summary>
    public bool? AllowAddingOptions { get; init; }

    /// <summary>Whether results remain hidden until the poll closes.</summary>
    public bool? HideResultsUntilCloses { get; init; }

    /// <summary>Whether voting is limited to users who have been chat members for more than 24 hours; for channel chats only.</summary>
    public bool? MembersOnly { get; init; }

    /// <summary>Country codes from which voting is allowed; from 0 through 12 ISO 3166-1 alpha-2 codes. Use <c>FT</c> for anonymous numbers.</summary>
    public IReadOnlyList<string>? CountryCodes { get; init; }

    /// <summary>Monotonically increasing zero-based identifiers of correct answers; required for quizzes.</summary>
    public IReadOnlyList<int>? CorrectOptionIds { get; init; }

    /// <summary>Quiz explanation, from 0 through 200 characters and at most two line feeds after entity parsing.</summary>
    public string? Explanation { get; init; }

    /// <summary>Mode for parsing entities in the quiz explanation.</summary>
    public string? ExplanationParseMode { get; init; }

    /// <summary>Special entities in the quiz explanation; can be specified instead of <see cref="ExplanationParseMode"/>.</summary>
    public IReadOnlyList<MessageEntity>? ExplanationEntities { get; init; }

    /// <summary>Media added to the quiz explanation.</summary>
    public IInputPollMedia? ExplanationMedia { get; init; }

    /// <summary>Number of seconds the poll remains active, from 5 through 2628000; cannot be combined with <see cref="CloseDate"/>.</summary>
    public int? OpenPeriod { get; init; }

    /// <summary>Unix timestamp when the poll closes, from 5 through 2628000 seconds in the future; cannot be combined with <see cref="OpenPeriod"/>.</summary>
    public int? CloseDate { get; init; }

    /// <summary>Whether the poll is immediately closed, which can be useful for previews.</summary>
    public bool? IsClosed { get; init; }

    /// <summary>Poll description, from 0 through 1024 characters after entity parsing.</summary>
    public string? Description { get; init; }

    /// <summary>Mode for parsing entities in the poll description.</summary>
    public string? DescriptionParseMode { get; init; }

    /// <summary>Special entities in the poll description; can be specified instead of <see cref="DescriptionParseMode"/>.</summary>
    public IReadOnlyList<MessageEntity>? DescriptionEntities { get; init; }

    /// <summary>Media added to the poll description.</summary>
    public IInputPollMedia? Media { get; init; }

    /// <summary>Whether to send the message silently.</summary>
    public bool? DisableNotification { get; init; }

    /// <summary>Whether to protect the message from forwarding and saving.</summary>
    public bool? ProtectContent { get; init; }

    /// <summary>Whether to allow paid high-throughput broadcasting.</summary>
    public bool? AllowPaidBroadcast { get; init; }

    /// <summary>Message effect identifier; for private chats only.</summary>
    public string? MessageEffectId { get; init; }

    /// <summary>Description of the message to reply to.</summary>
    public ReplyParameters? ReplyParameters { get; init; }

    /// <summary>Additional interface options for the message.</summary>
    public ReplyMarkup? ReplyMarkup { get; init; }
}
