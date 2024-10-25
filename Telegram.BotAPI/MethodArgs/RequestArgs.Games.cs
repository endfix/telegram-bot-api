using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.MethodArgs;

public sealed class SendGameArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public long ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public string GameShortName { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}

public sealed class SetGameScoreArgs : RequestArgs
{
    public long UserId { get; set; }

    public int Score { get; set; }

    public bool Force { get; set; }

    public bool DisableEditMessage { get; set; }

    public long ChatId { get; set; }

    public long MessageId { get; set; }

    public string InlineMessageId { get; set; }
}

public sealed class GetGameHighScoresArgs : RequestArgs
{
    public long UserId { get; set; }

    public long ChatId { get; set; }

    public long MessageId { get; set; }

    public string InlineMessageId { get; set; }
}