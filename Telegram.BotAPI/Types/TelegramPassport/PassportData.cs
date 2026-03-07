using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class PassportData
{
    public required IReadOnlyList<EncryptedPassportElement> Data { get; init; }

    public required EncryptedCredentials Credentials { get; init; }
}
