using System.Collections.Generic;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class EncryptedPassportElement
{
    public required EncryptedPassportElementTypes Type { get; init; }

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
