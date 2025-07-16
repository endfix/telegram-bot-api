using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class Poll
{
    public string Id { get; set; }

    public string Question { get; set; }

    public MessageEntity[] QuestionEntities { get; set; }

    public PollOption[] Options { get; set; }

    public int TotalVoterCount { get; set; }

    public bool IsClosed { get; set; }

    public bool IsAnonymous { get; set; }

    public PollTypes Type { get; set; }

    public bool AllowsMultipleAnswers { get; set; }

    public int CorrectOptionId { get; set; }

    public string Explanation { get; set; }

    public MessageEntity[] ExplanationEntities { get; set; }

    public int OpenPeriod { get; set; }

    public int CloseDate { get; set; }
}
