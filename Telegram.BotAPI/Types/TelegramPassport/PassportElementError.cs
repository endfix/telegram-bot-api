using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public abstract class PassportElementError
{
    public abstract PassportElementErrorSource Source { get; }

    public required virtual PassportElementErrorType Type { get; init; }

    public required virtual string Message { get; init; }
}

public sealed class PassportElementErrorDataField : PassportElementError
{
    public override PassportElementErrorSource Source => PassportElementErrorSource.Data;

    public required string FieldName { get; init; }

    public required string DataHash { get; init; }
}

public sealed class PassportElementErrorFrontSide : PassportElementError
{
    public override PassportElementErrorSource Source => PassportElementErrorSource.FrontSide;

    public required string FileHash { get; init; }
}

public sealed class PassportElementErrorReverseSide : PassportElementError
{
    public override PassportElementErrorSource Source => PassportElementErrorSource.ReverseSide;

    public required string FileHash { get; init; }
}

public sealed class PassportElementErrorSelfie : PassportElementError
{
    public override PassportElementErrorSource Source => PassportElementErrorSource.Selfie;

    public required string FileHash { get; init; }
}

public sealed class PassportElementErrorFile : PassportElementError
{
    public override PassportElementErrorSource Source => PassportElementErrorSource.File;

    public required string FileHash { get; init; }
}

public sealed class PassportElementErrorFiles : PassportElementError
{
    public override PassportElementErrorSource Source => PassportElementErrorSource.Files;

    public required IReadOnlyList<string> FileHashes { get; init; }
}

public sealed class PassportElementErrorTranslationFile : PassportElementError
{
    public override PassportElementErrorSource Source => PassportElementErrorSource.TranslationFile;

    public required string FileHash { get; init; }
}

public sealed class PassportElementErrorTranslationFiles : PassportElementError
{
    public override PassportElementErrorSource Source => PassportElementErrorSource.TranslationFiles;

    public required IReadOnlyList<string> FileHashes { get; init; }
}

public sealed class PassportElementErrorUnspecified : PassportElementError
{
    public override PassportElementErrorSource Source => PassportElementErrorSource.Unspecified;

    public required string ElementHash { get; init; }
}
