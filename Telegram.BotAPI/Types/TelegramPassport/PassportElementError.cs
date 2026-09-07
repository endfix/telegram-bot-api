using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for an error in a Telegram Passport element.</summary>
public abstract class PassportElementError
{
    /// <summary>Gets the source of the Passport element error.</summary>
    public abstract PassportElementErrorSource Source { get; }

    /// <summary>Type of the Passport element that contains the error.</summary>
    public required virtual PassportElementErrorType Type { get; init; }

    /// <summary>Error message shown to the user.</summary>
    public required virtual string Message { get; init; }
}

/// <summary>Describes an error in a data field.</summary>
public sealed class PassportElementErrorDataField : PassportElementError
{
    /// <inheritdoc/>
    public override PassportElementErrorSource Source => PassportElementErrorSource.Data;

    /// <summary>Name of the data field that contains the error.</summary>
    public required string FieldName { get; init; }

    /// <summary>Base64-encoded hash of the data field.</summary>
    public required string DataHash { get; init; }
}

/// <summary>Describes an error in the front side of a document.</summary>
public sealed class PassportElementErrorFrontSide : PassportElementError
{
    /// <inheritdoc/>
    public override PassportElementErrorSource Source => PassportElementErrorSource.FrontSide;

    /// <summary>Base64-encoded hash of the file with the error.</summary>
    public required string FileHash { get; init; }
}

/// <summary>Describes an error in the reverse side of a document.</summary>
public sealed class PassportElementErrorReverseSide : PassportElementError
{
    /// <inheritdoc/>
    public override PassportElementErrorSource Source => PassportElementErrorSource.ReverseSide;

    /// <summary>Base64-encoded hash of the file with the error.</summary>
    public required string FileHash { get; init; }
}

/// <summary>Describes an error in a document selfie.</summary>
public sealed class PassportElementErrorSelfie : PassportElementError
{
    /// <inheritdoc/>
    public override PassportElementErrorSource Source => PassportElementErrorSource.Selfie;

    /// <summary>Base64-encoded hash of the file with the error.</summary>
    public required string FileHash { get; init; }
}

/// <summary>Describes an error in a document file.</summary>
public sealed class PassportElementErrorFile : PassportElementError
{
    /// <inheritdoc/>
    public override PassportElementErrorSource Source => PassportElementErrorSource.File;

    /// <summary>Base64-encoded hash of the file with the error.</summary>
    public required string FileHash { get; init; }
}

/// <summary>Describes an error in one or more document files.</summary>
public sealed class PassportElementErrorFiles : PassportElementError
{
    /// <inheritdoc/>
    public override PassportElementErrorSource Source => PassportElementErrorSource.Files;

    /// <summary>Base64-encoded hashes of the files with errors.</summary>
    public required IReadOnlyList<string> FileHashes { get; init; }
}

/// <summary>Describes an error in a translated document file.</summary>
public sealed class PassportElementErrorTranslationFile : PassportElementError
{
    /// <inheritdoc/>
    public override PassportElementErrorSource Source => PassportElementErrorSource.TranslationFile;

    /// <summary>Base64-encoded hash of the file with the error.</summary>
    public required string FileHash { get; init; }
}

/// <summary>Describes an error in one or more translated document files.</summary>
public sealed class PassportElementErrorTranslationFiles : PassportElementError
{
    /// <inheritdoc/>
    public override PassportElementErrorSource Source => PassportElementErrorSource.TranslationFiles;

    /// <summary>Base64-encoded hashes of the files with errors.</summary>
    public required IReadOnlyList<string> FileHashes { get; init; }
}

/// <summary>Describes an error in an unspecified part of a Passport element.</summary>
public sealed class PassportElementErrorUnspecified : PassportElementError
{
    /// <inheritdoc/>
    public override PassportElementErrorSource Source => PassportElementErrorSource.Unspecified;

    /// <summary>Base64-encoded hash of the Passport element with the error.</summary>
    public required string ElementHash { get; init; }
}
