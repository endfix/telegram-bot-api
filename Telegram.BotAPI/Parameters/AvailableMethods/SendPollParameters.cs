using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendPollParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public string Question { get; set; }

    public string QuestionParseMode { get; set; }

    public MessageEntity[] QuestionEntities { get; set; }

    public InputPollOption[] Options { get; set; }

    public bool IsAnonymous { get; set; }

    public string Type { get; set; }

    public bool AllowsMultipleAnswers { get; set; }

    public int CorrectOptionId { get; set; }

    public string Explanation { get; set; }

    public string ExplanationParseMode { get; set; }

    public MessageEntity[] ExplanationEntities { get; set; }

    public int OpenPeriod { get; set; }

    public int CloseDate { get; set; }

    public bool IsClosed { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public bool AllowPaidBroadcast { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}
