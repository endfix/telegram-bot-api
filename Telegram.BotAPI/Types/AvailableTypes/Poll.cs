using System.Collections.Generic;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class Poll
{
    public required string Id { get; init; }

    public required string Question { get; init; }

    public IReadOnlyList<MessageEntity>? QuestionEntities { get; init; }

    public required IReadOnlyList<PollOption> Options { get; init; }

    public required int TotalVoterCount { get; init; }

    public required bool IsClosed { get; init; }

    public required bool IsAnonymous { get; init; }

    public required PollTypes Type { get; init; }

    public required bool AllowsMultipleAnswers { get; init; }

    public int? CorrectOptionId { get; init; }

    public string? Explanation { get; init; }

    public IReadOnlyList<MessageEntity>? ExplanationEntities { get; init; }

    public int? OpenPeriod { get; init; }

    public int? CloseDate { get; init; }
}
