using System.Collections.Generic;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "source")]
[JsonDerivedType(typeof(PassportElementErrorDataField), "data")]
[JsonDerivedType(typeof(PassportElementErrorFrontSide), "front_side")]
[JsonDerivedType(typeof(PassportElementErrorReverseSide), "reverse_side")]
[JsonDerivedType(typeof(PassportElementErrorSelfie), "selfie")]
[JsonDerivedType(typeof(PassportElementErrorFile), "file")]
[JsonDerivedType(typeof(PassportElementErrorFiles), "files")]
[JsonDerivedType(typeof(PassportElementErrorTranslationFile), "translation_file")]
[JsonDerivedType(typeof(PassportElementErrorTranslationFiles), "translation_files")]
[JsonDerivedType(typeof(PassportElementErrorUnspecified), "unspecified")]
public abstract class PassportElementError
{
    [JsonIgnore]
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
