using System.Collections.Generic;

namespace Telegram.BotAPI.Types.TelegramPassport;

/// <summary>
/// Describes documents or other Telegram Passport elements shared with the bot by the user.
/// </summary>
public sealed class EncryptedPassportElement
{
    /// <summary>
    /// Element type. One of “personal_details”, “passport”, “driver_license”, “identity_card”, “internal_passport”, “address”, “utility_bill”, 
    /// “bank_statement”, “rental_agreement”, “passport_registration”, “temporary_registration”, “phone_number”, “email”.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Optional. Base64-encoded encrypted Telegram Passport element data provided by the user; available only for “personal_details”, “passport”, 
    /// “driver_license”, “identity_card”, “internal_passport” and “address” types. 
    /// Can be decrypted and verified using the accompanying <see cref="EncryptedCredentials">EncryptedCredentials</see>.
    /// </summary>
    public string Data { get; set; }

    /// <summary>
    /// Optional. User's verified phone number; available only for “phone_number” type
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Optional. User's verified email address; available only for “email” type
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Optional. Array of encrypted files with documents provided by the user; available only for “utility_bill”, “bank_statement”, “rental_agreement”,
    /// “passport_registration” and “temporary_registration” types. 
    /// Files can be decrypted and verified using the accompanying <see cref="EncryptedCredentials" >EncryptedCredentials</see>.
    /// </summary>
    public List<PassportFile> Files { get; set; }

    /// <summary>
    /// Optional. Encrypted file with the front side of the document, provided by the user; available only for “passport”, “driver_license”, 
    /// “identity_card” and “internal_passport”. The file can be decrypted and verified using the accompanying <see cref="EncryptedCredentials">EncryptedCredentials</see>.
    /// </summary>
    public PassportFile FrontSide { get; set; }

    /// <summary>
    /// Optional. Encrypted file with the reverse side of the document, provided by the user; available only for “driver_license” and “identity_card”. 
    /// The file can be decrypted and verified using the accompanying <see cref="EncryptedCredentials">EncryptedCredentials</see>.
    /// </summary>
    public PassportFile ReverseSide { get; set; }

    /// <summary>
    /// Optional. Encrypted file with the selfie of the user holding a document, provided by the user; available if requested for “passport”, “driver_license”, 
    /// “identity_card” and “internal_passport”. 
    /// The file can be decrypted and verified using the accompanying <see cref="EncryptedCredentials">EncryptedCredentials</see>.
    /// </summary>
    public PassportFile Selfie { get; set; }

    /// <summary>
    /// Optional. Array of encrypted files with translated versions of documents provided by the user; available if requested for “passport”, “driver_license”, 
    /// “identity_card”, “internal_passport”, “utility_bill”, “bank_statement”, “rental_agreement”, “passport_registration” and “temporary_registration” types. 
    /// Files can be decrypted and verified using the accompanying <see cref="EncryptedCredentials">EncryptedCredentials</see>.
    /// </summary>
    public List<PassportFile> Translation { get; set; }

    /// <summary>
    /// Base64-encoded element hash for using in <see cref="PassportElementErrorUnspecified">PassportElementErrorUnspecified</see>
    /// </summary>
    public string Hash { get; set; }

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

        public const string PHONE_NUMBER = "phone_number";

        public const string EMAIL = "email";
    }
}
