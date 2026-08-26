using System.Collections.Generic;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendPollParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public required ChatIdSource ChatId { get; init; }

    public long? MessageThreadId { get; init; }

    public required string Question { get; init; }

    public string? QuestionParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? QuestionEntities { get; init; }

    public required IReadOnlyList<InputPollOption> Options { get; init; }

    public bool? IsAnonymous { get; init; }

    public PollType? Type { get; init; }

    public bool? AllowsMultipleAnswers { get; init; }

    public bool? AllowsRevoting { get; init; }

    public bool? ShuffleOptions { get; init; }

    public bool? AllowAddingOptions { get; init; }

    public bool? HideResultsUntilCloses { get; init; }

    public bool? MembersOnly { get; init; }

    public IReadOnlyList<string>? CountryCodes { get; init; }

    public IReadOnlyList<int>? CorrectOptionIds { get; init; }

    public string? Explanation { get; init; }

    public string? ExplanationParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? ExplanationEntities { get; init; }

    public InputPollMedia? ExplanationMedia { get; init; }

    public int? OpenPeriod { get; init; }

    public int? CloseDate { get; init; }

    public bool? IsClosed { get; init; }

    public string? Description { get; init; }

    public string? DescriptionParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? DescriptionEntities { get; init; }

    public InputPollMedia? Media { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public bool? AllowPaidBroadcast { get; init; }

    public string? MessageEffectId { get; init; }

    public ReplyParameters? ReplyParameters { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }
}
