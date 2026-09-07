namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies the Telegram Passport element that contains an error.</summary>
public enum PassportElementErrorType
{
    /// <summary>Personal details.</summary>
    PersonalDetails,

    /// <summary>An international passport.</summary>
    Passport,

    /// <summary>A driver's license.</summary>
    DriverLicense,

    /// <summary>An identity card.</summary>
    IdentityCard,

    /// <summary>An internal passport.</summary>
    InternalPassport,

    /// <summary>A residential address.</summary>
    Address,

    /// <summary>A utility bill.</summary>
    UtilityBill,

    /// <summary>A bank statement.</summary>
    BankStatement,

    /// <summary>A rental agreement.</summary>
    RentalAgreement,

    /// <summary>A passport registration document.</summary>
    PassportRegistration,

    /// <summary>A temporary registration document.</summary>
    TemporaryRegistration
}
