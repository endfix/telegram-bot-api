using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a native Telegram poll.</summary>
public sealed class Poll
{
    /// <summary>Unique poll identifier.</summary>
    public required string Id { get; init; }

    /// <summary>Poll question, 1-300 characters.</summary>
    public required string Question { get; init; }

    /// <summary>Special entities that appear in the poll question, if available.</summary>
    public IReadOnlyList<MessageEntity>? QuestionEntities { get; init; }

    /// <summary>List of poll answer options.</summary>
    public required IReadOnlyList<PollOption> Options { get; init; }

    /// <summary>Total number of users that voted in the poll.</summary>
    public required int TotalVoterCount { get; init; }

    /// <summary>Indicates whether the poll is closed.</summary>
    public required bool IsClosed { get; init; }

    /// <summary>Indicates whether the poll is anonymous.</summary>
    public required bool IsAnonymous { get; init; }

    /// <summary>Poll type.</summary>
    public required PollType Type { get; init; }

    /// <summary>Indicates whether the poll allows multiple answers.</summary>
    public required bool AllowsMultipleAnswers { get; init; }

    /// <summary>Indicates whether users are allowed to change their vote.</summary>
    public required bool AllowsRevoting { get; init; }

    /// <summary>Indicates whether the poll is limited to members.</summary>
    public required bool MembersOnly { get; init; }

    /// <summary>Two-letter ISO 3166-1 alpha-2 country codes for a members-only poll, if available.</summary>
    public IReadOnlyList<string>? CountryCodes { get; init; }

    /// <summary>Identifiers of the correct answer options for a quiz, if available.</summary>
    public IReadOnlyList<int>? CorrectOptionIds { get; init; }

    /// <summary>Poll explanation, if available.</summary>
    public string? Explanation { get; init; }

    /// <summary>Special entities that appear in the poll explanation, if available.</summary>
    public IReadOnlyList<MessageEntity>? ExplanationEntities { get; init; }

    /// <summary>Media attached to the poll explanation, if available.</summary>
    public PollMedia? ExplanationMedia { get; init; }

    /// <summary>Amount of time in seconds the poll will be active after creation, if available.</summary>
    public int? OpenPeriod { get; init; }

    /// <summary>Point in time when the poll will be automatically closed, in Unix time, if available.</summary>
    public int? CloseDate { get; init; }

    /// <summary>Poll description, if available.</summary>
    public string? Description { get; init; }

    /// <summary>Special entities that appear in the poll description, if available.</summary>
    public IReadOnlyList<MessageEntity>? DescriptionEntities { get; init; }

    /// <summary>Media attached to the poll description, if available.</summary>
    public PollMedia? Media { get; init; }
}
