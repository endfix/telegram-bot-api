using System.Collections.Generic;

namespace Telegram.BotAPI.Types.TelegramPassport;

/// <summary>
/// This object represents an error in the Telegram Passport element which was submitted that should be resolved by the user. It should be one of:
/// <see cref="PassportElementErrorDataField">PassportElementErrorDataField<\see> or
/// <see cref="PassportElementErrorFrontSide">PassportElementErrorFrontSide<\see> or
/// <see cref="PassportElementErrorReverseSide">PassportElementErrorReverseSide<\see> or
/// <see cref="PassportElementErrorSelfie">PassportElementErrorSelfie<\see> or
/// <see cref="PassportElementErrorFile">PassportElementErrorFile<\see> or
/// <see cref="PassportElementErrorFiles">PassportElementErrorFiles<\see> or
/// <see cref="PassportElementErrorTranslationFile">PassportElementErrorTranslationFile<\see> or
/// <see cref="PassportElementErrorTranslationFiles">PassportElementErrorTranslationFiles<\see> or
/// <see cref="PassportElementErrorUnspecified">PassportElementErrorUnspecified<\see>
/// </summary>
public abstract class PassportElementError
{
    public abstract string Source { get; }

    public virtual string Type { get; set; }

    /// <summary>
    /// Error message
    /// </summary>
    public virtual string Message { get; set; }

    public static class Sources
    {
        public const string DATA = "data";

        public const string FRONT_SIDE = "front_side";

        public const string REVERSE_SIDE = "reverse_side";

        public const string SELFIE = "selfie";

        public const string FILE = "file";

        public const string FILES = "files";

        public const string TRANSLATION_FILE = "translation_file";

        public const string TRANSLATION_FILES = "translation_files";

        public const string UNSPECIFIED = "unspecified";
    }

    public static class Types
    {
        public const string PERSONAL_DETAILS = "personal_details";

        public const string PASSPORT = "passport";

        public const string DRIVER_LICENSE = "driver_license";

        public const string IDENTITY_CARD = "identity_card";

        public const string INTERNAL_PASSPORT = "internal_passport";

        public const string ADDRESS = "address";

        public const string UTILITY_BILL = "utility_bill";

        public const string BANK_STATEMENT = "bank_statement";

        public const string RENTAL_AGREEMENT = "rental_agreement";

        public const string PASSPORT_REGISTRATION = "passport_registration";

        public const string TEMPORARY_REGISTRATION = "temporary_registration";
    }
}

/// <summary>
/// Represents an issue in one of the data fields that was provided by the user. The error is considered resolved when the field's value changes.
/// </summary>
public sealed class PassportElementErrorDataField : PassportElementError
{
    /// <summary>
    /// Error source, must be data
    /// </summary>
    public override string Source => Sources.DATA;

    /// <summary>
    /// The section of the user's Telegram Passport which has the error, one of “personal_details”, “passport”, “driver_license”, “identity_card”, “internal_passport”, “address”
    /// </summary>
    public override string Type { get; set; }

    /// <summary>
    /// Name of the data field which has the error
    /// </summary>
    public string FieldName { get; set; }

    /// <summary>
    /// Base64-encoded data hash
    /// </summary>
    public string DataHash { get; set; }
}

/// <summary>
/// Represents an issue with the front side of a document. The error is considered resolved when the file with the front side of the document changes.
/// </summary>
public sealed class PassportElementErrorFrontSide : PassportElementError
{
    /// <summary>
    /// Error source, must be front_side
    /// </summary>
    public override string Source => Sources.FRONT_SIDE;

    /// <summary>
    /// Base64-encoded hash of the file with the front side of the document
    /// </summary>
    public string FileHash { get; set; }
}

/// <summary>
/// Represents an issue with the reverse side of a document. The error is considered resolved when the file with reverse side of the document changes.
/// </summary>
public sealed class PassportElementErrorReverseSide : PassportElementError
{
    /// <summary>
    /// Error source, must be reverse_side
    /// </summary>
    public override string Source => Sources.REVERSE_SIDE;

    /// <summary>
    /// The section of the user's Telegram Passport which has the issue, one of “driver_license”, “identity_card”
    /// </summary>
    public override string Type { get; set; }

    /// <summary>
    /// Base64-encoded hash of the file with the reverse side of the document
    /// </summary>
    public string FileHash { get; set; }
}

/// <summary>
/// Represents an issue with the selfie with a document. The error is considered resolved when the file with the selfie changes.
/// </summary>
public sealed class PassportElementErrorSelfie : PassportElementError
{
    /// <summary>
    /// Error source, must be selfie
    /// </summary>
    public override string Source => Sources.SELFIE;

    /// <summary>
    /// The section of the user's Telegram Passport which has the issue, one of “passport”, “driver_license”, “identity_card”, “internal_passport”
    /// </summary>
    public override string Type { get; set; }

    /// <summary>
    /// Base64-encoded hash of the file with the selfie
    /// </summary>
    public string FileHash { get; set; }
}

/// <summary>
/// Represents an issue with a document scan. The error is considered resolved when the file with the document scan changes.
/// </summary>
public sealed class PassportElementErrorFile : PassportElementError
{
    /// <summary>
    /// Error source, must be file
    /// </summary>
    public override string Source => Sources.FILE;

    /// <summary>
    /// The section of the user's Telegram Passport which has the issue, one of “utility_bill”, “bank_statement”, “rental_agreement”, “passport_registration”, “temporary_registration”
    /// </summary>
    public override string Type { get; set; }

    /// <summary>
    /// Base64-encoded file hash
    /// </summary>
    public string FileHash { get; set; }
}

/// <summary>
/// Represents an issue with a list of scans. The error is considered resolved when the list of files containing the scans changes.
/// </summary>
public sealed class PassportElementErrorFiles : PassportElementError
{
    /// <summary>
    /// Error source, must be files
    /// </summary>
    public override string Source => Sources.FILES;

    /// <summary>
    /// The section of the user's Telegram Passport which has the issue, one of “utility_bill”, “bank_statement”, “rental_agreement”, “passport_registration”, “temporary_registration”
    /// </summary>
    public override string Type { get; set; }

    /// <summary>
    /// List of base64-encoded file hashes
    /// </summary>
    public List<string> FileHashes { get; set; }
}

/// <summary>
/// Represents an issue with one of the files that constitute the translation of a document. The error is considered resolved when the file changes.
/// </summary>
public sealed class PassportElementErrorTranslationFile : PassportElementError
{
    /// <summary>
    /// Error source, must be translation_file
    /// </summary>
    public override string Source => Sources.TRANSLATION_FILE;

    /// <summary>
    /// Type of element of the user's Telegram Passport which has the issue, one of “passport”, “driver_license”, “identity_card”, “internal_passport”,
    /// “utility_bill”, “bank_statement”, “rental_agreement”, “passport_registration”, “temporary_registration”
    /// </summary>
    public override string Type { get; set; }

    /// <summary>
    /// Base64-encoded file hash
    /// </summary>
    public string FileHash { get; set; }
}

/// <summary>
/// Represents an issue with the translated version of a document. The error is considered resolved when a file with the document translation change.
/// </summary>
public sealed class PassportElementErrorTranslationFiles : PassportElementError
{
    /// <summary>
    /// Error source, must be translation_files
    /// </summary>
    public override string Source => Sources.TRANSLATION_FILES;

    /// <summary>
    /// Type of element of the user's Telegram Passport which has the issue, one of “passport”, “driver_license”, “identity_card”, “internal_passport”, “utility_bill”,
    /// “bank_statement”, “rental_agreement”, “passport_registration”, “temporary_registration”
    /// </summary>
    public override string Type { get; set; }

    /// <summary>
    /// List of base64-encoded file hashes
    /// </summary>
    public List<string> FileHashes { get; set; }
}

/// <summary>
/// Represents an issue in an unspecified place. The error is considered resolved when new data is added.
/// </summary>
public sealed class PassportElementErrorUnspecified : PassportElementError
{
    /// <summary>
    /// Error source, must be unspecified
    /// </summary>
    public override string Source => Sources.UNSPECIFIED;

    /// <summary>
    /// Type of element of the user's Telegram Passport which has the issue
    /// </summary>
    public override string Type { get; set; }

    /// <summary>
    /// Base64-encoded element hash
    /// </summary>
    public string ElementHash { get; set; }
}
