namespace Telegram.BotAPI.Types;

public sealed class CallbackQuery
{
    public required string Id { get; init; }

    public required User From { get; init; }

    public MaybeInaccessibleMessage? Message { get; init; }

    public string? InlineMessageId { get; init; }

    public required string ChatInstance { get; init; }

    public string? Data { get; init; }

    public string? GameShortName { get; init; }
}
