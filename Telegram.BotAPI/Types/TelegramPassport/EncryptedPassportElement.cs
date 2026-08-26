using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class EncryptedPassportElement
{
    public required EncryptedPassportElementType Type { get; init; }

    public string? Data { get; init; }

    public string? PhoneNumber { get; init; }

    public string? Email { get; init; }

    public IReadOnlyList<PassportFile>? Files { get; init; }

    public PassportFile? FrontSide { get; init; }

    public PassportFile? ReverseSide { get; init; }

    public PassportFile? Selfie { get; init; }

    public IReadOnlyList<PassportFile>? Translation { get; init; }

    public string? Hash { get; init; }
}
