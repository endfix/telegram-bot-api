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

    public required PollType Type { get; init; }

    public required bool AllowsMultipleAnswers { get; init; }

    public required bool AllowsRevoting { get; init; }

    public required bool MembersOnly { get; init; }

    public IReadOnlyList<string>? CountryCodes { get; init; }

    public IReadOnlyList<int>? CorrectOptionIds { get; init; }

    public string? Explanation { get; init; }

    public IReadOnlyList<MessageEntity>? ExplanationEntities { get; init; }

    public PollMedia? ExplanationMedia { get; init; }

    public int? OpenPeriod { get; init; }

    public int? CloseDate { get; init; }

    public string? Description { get; init; }

    public IReadOnlyList<MessageEntity>? DescriptionEntities { get; init; }

    public PollMedia? Media { get; init; }
}
