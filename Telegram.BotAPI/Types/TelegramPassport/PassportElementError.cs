using System.Collections.Generic;

namespace Telegram.BotAPI.Types.TelegramPassport;

// https://core.telegram.org/bots/api#passportelementerror
public abstract class PassportElementError
{
    public abstract string Source { get; }

    public virtual string Type { get; set; }

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

// https://core.telegram.org/bots/api#passportelementerrordatafield
public sealed class PassportElementErrorDataField : PassportElementError
{
    public override string Source => Sources.DATA;

    public string FieldName { get; set; }

    public string DataHash { get; set; }
}

// https://core.telegram.org/bots/api#passportelementerrorfile
public sealed class PassportElementErrorFile : PassportElementError
{
    public override string Source => Sources.FILE;

    public string FileHash { get; set; }
}

// https://core.telegram.org/bots/api#passportelementerrorfiles
public sealed class PassportElementErrorFiles : PassportElementError
{
    public override string Source => Sources.FILES;

    public List<string> FileHashes { get; set; }
}

// https://core.telegram.org/bots/api#passportelementerrorfrontside
public sealed class PassportElementErrorFrontSide : PassportElementError
{
    public override string Source => Sources.FRONT_SIDE;

    public string FileHash { get; set; }
}

// https://core.telegram.org/bots/api#passportelementerrorreverseside
public sealed class PassportElementErrorReverseSide : PassportElementError
{
    public override string Source => Sources.REVERSE_SIDE;

    public string FileHash { get; set; }
}

// https://core.telegram.org/bots/api#passportelementerrorselfie
public sealed class PassportElementErrorSelfie : PassportElementError
{
    public override string Source => Sources.SELFIE;

    public string FileHash { get; set; }
}

// https://core.telegram.org/bots/api#passportelementerrortranslationfile
public sealed class PassportElementErrorTranslationFile : PassportElementError
{
    public override string Source => Sources.TRANSLATION_FILE;

    public string FileHash { get; set; }
}

// https://core.telegram.org/bots/api#passportelementerrortranslationfiles
public sealed class PassportElementErrorTranslationFiles : PassportElementError
{
    public override string Source => Sources.TRANSLATION_FILES;

    public List<string> FileHashes { get; set; }
}

// https://core.telegram.org/bots/api#passportelementerrorunspecified
public sealed class PassportElementErrorUnspecified : PassportElementError
{
    public override string Source => Sources.UNSPECIFIED;

    public string ElementHash { get; set; }
}
