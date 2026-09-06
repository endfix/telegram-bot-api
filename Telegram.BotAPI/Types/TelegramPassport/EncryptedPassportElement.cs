using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes documents or other Telegram Passport elements shared with the bot by the user.</summary>
public sealed class EncryptedPassportElement
{
    /// <summary>Element type.</summary>
    public required EncryptedPassportElementType Type { get; init; }

    /// <summary>Optional. Base64-encoded encrypted Telegram Passport element data; available only for data-based element types.</summary>
    public string? Data { get; init; }

    /// <summary>Optional. User's verified phone number; available only for the <c>phone_number</c> element type.</summary>
    public string? PhoneNumber { get; init; }

    /// <summary>Optional. User's verified email address; available only for the <c>email</c> element type.</summary>
    public string? Email { get; init; }

    /// <summary>Optional. Array of encrypted document files; available only for document types represented by multiple files.</summary>
    public IReadOnlyList<PassportFile>? Files { get; init; }

    /// <summary>Optional. Encrypted file with the front side of the document.</summary>
    public PassportFile? FrontSide { get; init; }

    /// <summary>Optional. Encrypted file with the reverse side of the document.</summary>
    public PassportFile? ReverseSide { get; init; }

    /// <summary>Optional. Encrypted selfie of the user holding a document.</summary>
    public PassportFile? Selfie { get; init; }

    /// <summary>Optional. Array of encrypted files with translated versions of the documents.</summary>
    public IReadOnlyList<PassportFile>? Translation { get; init; }

    /// <summary>Base64-encoded element hash for use in <see cref="PassportElementErrorUnspecified"/>.</summary>
    public string? Hash { get; init; }
}
