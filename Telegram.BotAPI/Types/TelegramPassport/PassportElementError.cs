using System.Collections.Generic;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class PassportElementError
{
    public abstract PassportElementErrorSources Source { get; }

    public required virtual PassportElementErrorTypes Type { get; init; }

    public required virtual string Message { get; init; }
}

public sealed class PassportElementErrorDataField : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.Data;

    public required string FieldName { get; init; }

    public required string DataHash { get; init; }
}

public sealed class PassportElementErrorFrontSide : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.FrontSide;

    public required string FileHash { get; init; }
}

public sealed class PassportElementErrorReverseSide : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.ReverseSide;

    public required string FileHash { get; init; }
}

public sealed class PassportElementErrorSelfie : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.Selfie;

    public required string FileHash { get; init; }
}

public sealed class PassportElementErrorFile : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.File;

    public required string FileHash { get; init; }
}

public sealed class PassportElementErrorFiles : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.Files;

    public required IReadOnlyList<string> FileHashes { get; init; }
}

public sealed class PassportElementErrorTranslationFile : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.TranslationFile;

    public required string FileHash { get; init; }
}

public sealed class PassportElementErrorTranslationFiles : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.TranslationFiles;

    public required IReadOnlyList<string> FileHashes { get; init; }
}

public sealed class PassportElementErrorUnspecified : PassportElementError
{
    public override PassportElementErrorSources Source => PassportElementErrorSources.Unspecified;

    public required string ElementHash { get; init; }
}
