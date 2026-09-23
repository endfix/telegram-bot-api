using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace CustomBot.Requests;

internal sealed class CustomPhotoParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required PhotoSource Photo { get; init; }
}

internal sealed class CustomTextParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required string Text { get; init; }
}
