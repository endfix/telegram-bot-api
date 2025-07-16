using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class PassportElementError
{
    public abstract PassportElementErrorSources Source { get; }

    public virtual string Type { get; set; }

    public virtual string Message { get; set; }
}

public sealed class PassportElementErrorDataField : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.Data;

    public override string Type { get; set; }

    public string FieldName { get; set; }

    public string DataHash { get; set; }
}

public sealed class PassportElementErrorFrontSide : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.FrontSide;

    public string FileHash { get; set; }
}

public sealed class PassportElementErrorReverseSide : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.ReverseSide;

    public override string Type { get; set; }

    public string FileHash { get; set; }
}

public sealed class PassportElementErrorSelfie : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.Selfie;

    public override string Type { get; set; }

    public string FileHash { get; set; }
}

public sealed class PassportElementErrorFile : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.File;

    public override string Type { get; set; }

    public string FileHash { get; set; }
}

public sealed class PassportElementErrorFiles : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.Files;

    public override string Type { get; set; }

    public string[] FileHashes { get; set; }
}

public sealed class PassportElementErrorTranslationFile : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.TranslationFile;

    public override string Type { get; set; }

    public string FileHash { get; set; }
}

public sealed class PassportElementErrorTranslationFiles : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.TranslationFiles;

    public override string Type { get; set; }

    public string[] FileHashes { get; set; }
}

public sealed class PassportElementErrorUnspecified : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.Unspecified;

    public override string Type { get; set; }

    public string ElementHash { get; set; }
}
