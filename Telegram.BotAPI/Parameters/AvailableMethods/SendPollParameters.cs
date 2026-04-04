using System.Collections.Generic;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendPollParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public required ChatIdSource ChatId { get; init; }

    public int? MessageThreadId { get; init; }

    public required string Question { get; init; }

    public string? QuestionParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? QuestionEntities { get; init; }

    public required IReadOnlyList<InputPollOption> Options { get; init; }

    public bool? IsAnonymous { get; init; }

    public PollTypes? Type { get; init; }

    public bool? AllowsMultipleAnswers { get; init; }

    public int? CorrectOptionId { get; init; }

    public string? Explanation { get; init; }

    public string? ExplanationParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? ExplanationEntities { get; init; }

    public int? OpenPeriod { get; init; }

    public int? CloseDate { get; init; }

    public bool? IsClosed { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public bool? AllowPaidBroadcast { get; init; }

    public string? MessageEffectId { get; init; }

    public ReplyParameters? ReplyParameters { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }
}
