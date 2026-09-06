using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes Telegram Passport data shared with the bot by the user.</summary>
public sealed class PassportData
{
    /// <summary>Array with information about documents and other Telegram Passport elements shared with the bot.</summary>
    public required IReadOnlyList<EncryptedPassportElement> Data { get; init; }

    /// <summary>Encrypted credentials required to decrypt the data.</summary>
    public required EncryptedCredentials Credentials { get; init; }
}
