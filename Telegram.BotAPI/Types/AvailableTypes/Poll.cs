using System.Collections.Generic;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class Poll
{
    public string Id { get; set; }

    public string Question { get; set; }

    public List<MessageEntity> QuestionEntities { get; set; }

    public List<PollOption> Options { get; set; }

    public int TotalVoterCount { get; set; }

    public bool IsClosed { get; set; }

    public bool IsAnonymous { get; set; }

    public string Type { get; set; }

    public bool AllowsMultipleAnswers { get; set; }

    public int CorrectOptionId { get; set; }

    public string Explanation { get; set; }

    public List<MessageEntity> ExplanationEntities { get; set; }

    public int OpenPeriod { get; set; }

    public int CloseDate { get; set; }

    public static class Types
    {
        public const string REGULAR = "regular";

        public const string QUIZ = "quiz";
    }
}
